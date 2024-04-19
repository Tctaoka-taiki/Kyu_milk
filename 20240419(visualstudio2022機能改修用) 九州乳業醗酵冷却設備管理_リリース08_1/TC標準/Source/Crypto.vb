Public Class Crypto
    '''
    '''
    Public Class RSA
        ''' <summary>
        ''' 公開鍵と秘密鍵を作成して返す
        ''' </summary>
        ''' <param name="publicKey">作成された公開鍵(XML形式)</param>
        ''' <param name="privateKey">作成された秘密鍵(XML形式)</param>
        Public Shared Sub CreateKeys(ByRef publicKey As String, _
                                    ByRef privateKey As String)
            'RSACryptoServiceProviderオブジェクトの作成
            '（Web Service,ASP Page,COM+の時は次のように
            'UseMachineKeyStoreを指定する）
            Dim CSPParam As New System.Security.Cryptography.CspParameters
            CSPParam.Flags = _
                System.Security.Cryptography.CspProviderFlags.UseMachineKeyStore
            Dim rsa As New _
                System.Security.Cryptography.RSACryptoServiceProvider(CSPParam)

            '公開鍵をXML形式で取得
            publicKey = rsa.ToXmlString(False)
            '秘密鍵をXML形式で取得
            privateKey = rsa.ToXmlString(True)
        End Sub

        ''' <summary>
        ''' 公開鍵を使って文字列を暗号化する
        ''' </summary>
        ''' <param name="str">暗号化する文字列</param>
        ''' <param name="publicKey">暗号化に使用する公開鍵(XML形式)</param>
        ''' <returns>暗号化された文字列</returns>
        Public Shared Function Encrypt(ByVal str As String, _
                                    ByVal publicKey As String) As String
            'RSACryptoServiceProviderオブジェクトの作成
            Dim CSPParam As New System.Security.Cryptography.CspParameters
            CSPParam.Flags = _
                System.Security.Cryptography.CspProviderFlags.UseMachineKeyStore
            Dim rsa As New _
                System.Security.Cryptography.RSACryptoServiceProvider(CSPParam)

            '公開鍵を指定
            rsa.FromXmlString(publicKey)

            '暗号化する文字列をバイト配列に
            Dim data As Byte() = System.Text.Encoding.UTF8.GetBytes(str)
            '暗号化する
            '（XP以降の場合のみ2項目にTrueを指定し、OAEPパディングを使用できる）
            Dim encryptedData As Byte() = rsa.Encrypt(data, False)

            'Base64で結果を文字列に変換
            Return System.Convert.ToBase64String(encryptedData)
        End Function

        ''' <summary>
        ''' 秘密鍵を使って文字列を復号化する
        ''' </summary>
        ''' <param name="str">Encryptメソッドにより暗号化された文字列</param>
        ''' <param name="privateKey">復号化に必要な秘密鍵(XML形式)</param>
        ''' <returns>復号化された文字列</returns>
        Public Shared Function Decrypt(ByVal str As String, _
                                    ByVal privateKey As String) As String
            'RSACryptoServiceProviderオブジェクトの作成
            Dim CSPParam As New System.Security.Cryptography.CspParameters
            CSPParam.Flags = _
                System.Security.Cryptography.CspProviderFlags.UseMachineKeyStore
            Dim rsa As New _
                System.Security.Cryptography.RSACryptoServiceProvider(CSPParam)

            '秘密鍵を指定
            rsa.FromXmlString(privateKey)

            '復号化する文字列をバイト配列に
            Dim data As Byte() = System.Convert.FromBase64String(str)
            '復号化する
            Dim decryptedData As Byte() = rsa.Decrypt(data, False)

            '結果を文字列に変換
            Return System.Text.Encoding.UTF8.GetString(decryptedData)
        End Function
    End Class

    ''' <summary>
    ''' 共通鍵暗号化処理を提供します
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Key

        ' API functions
        Private Class WinApi
#Region " Crypto API imports "

            Private Const ALG_CLASS_HASH As Integer = (4 << 13)
            Private Const ALG_TYPE_ANY As Integer = 0
            Private Const ALG_CLASS_DATA_ENCRYPT As Integer = (3 << 13)
            Private Const ALG_TYPE_STREAM As Integer = (4 << 9)
            Private Const ALG_TYPE_BLOCK As Integer = (3 << 9)

            Private Const ALG_SID_DES As Integer = 1
            Private Const ALG_SID_RC4 As Integer = 1
            Private Const ALG_SID_RC2 As Integer = 2
            Private Const ALG_SID_MD5 As Integer = 3

            Public Const MS_DEF_PROV As String = "Microsoft Base Cryptographic Provider v1.0"

            Public Const PROV_RSA_FULL As Integer = 1
            Public Const CRYPT_VERIFYCONTEXT As Integer = &HF0000000
            Public Const CRYPT_EXPORTABLE As Integer = &H1

            Public Shared ReadOnly CALG_MD5 As Integer = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_MD5
            Public Shared ReadOnly CALG_DES As Integer = ALG_CLASS_DATA_ENCRYPT Or ALG_TYPE_BLOCK Or ALG_SID_DES
            Public Shared ReadOnly CALG_RC2 As Integer = ALG_CLASS_DATA_ENCRYPT Or ALG_TYPE_BLOCK Or ALG_SID_RC2
            Public Shared ReadOnly CALG_RC4 As Integer = ALG_CLASS_DATA_ENCRYPT Or ALG_TYPE_STREAM Or ALG_SID_RC4

#If COMPACT_FRAMEWORK Then
	Private Const CryptDll As String = "coredll.dll"
	Private Const KernelDll As String = "coredll.dll" '
#Else
            Private Const CryptDll As String = "advapi32.dll"
            Private Const KernelDll As String = "kernel32.dll" '
#End If

            <System.Runtime.InteropServices.DllImport(CryptDll)> _
            Public Shared Function CryptAcquireContext( _
             ByRef phProv As IntPtr, ByVal pszContainer As String, _
             ByVal pszProvider As String, ByVal dwProvType As Integer, _
             ByVal dwFlags As Integer) As Boolean
            End Function

            <System.Runtime.InteropServices.DllImport(CryptDll)> _
            Public Shared Function CryptReleaseContext( _
             ByVal hProv As IntPtr, ByVal dwFlags As Integer) As Boolean
            End Function

            <System.Runtime.InteropServices.DllImport(CryptDll)> _
            Public Shared Function CryptDeriveKey( _
             ByVal hProv As IntPtr, ByVal Algid As Integer, _
             ByVal hBaseData As IntPtr, ByVal dwFlags As Integer, _
             ByRef phKey As IntPtr) As Boolean
            End Function

            <System.Runtime.InteropServices.DllImport(CryptDll)> _
            Public Shared Function CryptCreateHash( _
             ByVal hProv As IntPtr, ByVal Algid As Integer, _
             ByVal hKey As IntPtr, ByVal dwFlags As Integer, _
             ByRef phHash As IntPtr) As Boolean
            End Function

            <System.Runtime.InteropServices.DllImport(CryptDll)> _
            Public Shared Function CryptHashData( _
             ByVal hHash As IntPtr, ByVal pbData() As Byte, ByVal dwDataLen As Integer, _
             ByVal dwFlags As Integer) As Boolean
            End Function

            <System.Runtime.InteropServices.DllImport(CryptDll)> _
            Public Shared Function CryptEncrypt( _
             ByVal hKey As IntPtr, ByVal hHash As IntPtr, _
             ByVal Final As Boolean, ByVal dwFlags As Integer, _
             ByVal pbData() As Byte, ByRef pdwDataLen As Integer, _
             ByVal dwBufLen As Integer) As Boolean
            End Function

            <System.Runtime.InteropServices.DllImport(CryptDll)> _
            Public Shared Function CryptDecrypt( _
             ByVal hKey As IntPtr, ByVal hHash As IntPtr, _
             ByVal Final As Boolean, ByVal dwFlags As Integer, _
             ByVal pbData() As Byte, ByRef pdwDataLen As Integer) As Boolean
            End Function

            <System.Runtime.InteropServices.DllImport(CryptDll)> _
            Public Shared Function CryptDestroyHash(ByVal hHash As IntPtr) As Boolean
            End Function

            <System.Runtime.InteropServices.DllImport(CryptDll)> _
            Public Shared Function CryptDestroyKey(ByVal hKey As IntPtr) As Boolean
            End Function

#End Region

#Region " Error reporting imports "

            Public Const FORMAT_MESSAGE_FROM_SYSTEM As Integer = &H1000

            <System.Runtime.InteropServices.DllImport(KernelDll)> _
            Public Shared Function GetLastError() As Integer
            End Function

            <System.Runtime.InteropServices.DllImport(KernelDll)> _
            Public Shared Function FormatMessage( _
             ByVal dwFlags As Integer, ByVal lpSource As String, _
             ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, _
             ByVal lpBuffer As System.Text.StringBuilder, ByVal nSize As Integer, _
             ByVal Arguments() As String) As Integer
            End Function

#End Region
        End Class

        Private Sub New()
        End Sub


        ''' <summary>
        ''' バイト列をエンコードします
        ''' </summary>
        ''' <param name="passphrase">共通鍵パスワード文字列</param>
        ''' <param name="data">暗号化したいバイト列</param>
        ''' <returns>暗号化されたバイト列</returns>
        ''' <remarks></remarks>
        Public Shared Function Encrypt(ByVal passphrase As String, ByVal data() As Byte) As Byte()
            Dim buffer As Byte() = Nothing

            '暗号化ハンドル
            Dim hProv As IntPtr = IntPtr.Zero
            Dim hKey As IntPtr = IntPtr.Zero

            Try
                ' 暗号化プロバイダを取得します
                If Not WinApi.CryptAcquireContext(hProv, Nothing, WinApi.MS_DEF_PROV, WinApi.PROV_RSA_FULL, WinApi.CRYPT_VERIFYCONTEXT) Then
                    Failed("CryptAcquireContext")
                End If

                ' パスワードの暗号化ハンドラを取得
                hKey = GetCryptoKey(hProv, passphrase)

                ' 暗号化バッファの長さを指定します
                Dim dataLength As Integer = data.Length
                Dim bufLength As Integer = data.Length

                ' 暗号化します
                If Not WinApi.CryptEncrypt(hKey, IntPtr.Zero, True, 0, Nothing, dataLength, bufLength) Then
                    Failed("CryptEncrypt")
                End If

                ' 再度暗号化します
                buffer = New Byte(dataLength - 1) {}
                System.Buffer.BlockCopy(data, 0, buffer, 0, data.Length)

                dataLength = data.Length
                bufLength = buffer.Length
                If Not WinApi.CryptEncrypt(hKey, IntPtr.Zero, True, 0, buffer, dataLength, bufLength) Then
                    Failed("CryptEncrypt")
                End If
            Finally
                ' パスワードのハンドラを解放します
                If Not hKey.Equals(IntPtr.Zero) Then
                    WinApi.CryptDestroyKey(hKey)
                End If

                '暗号化プロバイダのハンドラを解放します
                If Not hProv.Equals(IntPtr.Zero) Then
                    WinApi.CryptReleaseContext(hProv, 0)
                End If
            End Try

            Return buffer
        End Function


        ''' <summary>
        ''' バイト列をデコードします
        ''' </summary>
        ''' <param name="passphrase"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Decrypt(ByVal passphrase As String, ByVal data() As Byte) As Byte()
            'ソースをコピーします
            Dim dataCopy As Byte() = CType(data.Clone(), Byte())

            'バッファを準備します
            Dim buffer As Byte() = Nothing

            'ハンドル変数
            Dim hProv As IntPtr = IntPtr.Zero
            Dim hKey As IntPtr = IntPtr.Zero

            Try
                ' 暗号化プロバイダを取得します
                If Not WinApi.CryptAcquireContext(hProv, Nothing, WinApi.MS_DEF_PROV, WinApi.PROV_RSA_FULL, WinApi.CRYPT_VERIFYCONTEXT) Then
                    Failed("CryptAcquireContext")
                End If

                ' パスワードの暗号化ハンドラを取得
                hKey = GetCryptoKey(hProv, passphrase)

                ' 暗号化バッファの長さを指定します
                Dim dataLength As Integer = dataCopy.Length

                ' 復号化します
                'If Not WinApi.CryptDecrypt(hKey, IntPtr.Zero, True, 0, dataCopy, dataLength) Then
                'Failed("CryptDecrypt")
                'End If

                '結果をコピーします
                buffer = New Byte(dataLength - 1) {}
                System.Buffer.BlockCopy(dataCopy, 0, buffer, 0, dataLength)
            Finally
                ' パスワードのハンドラを解放します
                If Not hKey.Equals(IntPtr.Zero) Then
                    WinApi.CryptDestroyKey(hKey)
                End If

                '暗号化プロバイダのハンドラを解放します
                If Not hProv.Equals(IntPtr.Zero) Then
                    WinApi.CryptReleaseContext(hProv, 0)
                End If
            End Try

            Return buffer
        End Function

        ''' <summary>
        ''' 文字列を暗号化して暗号化文字列を返す
        ''' </summary>
        ''' <param name="passphrase">パスワード</param>
        ''' <param name="planeText">データ文字列</param>
        ''' <returns>暗号化された文字列</returns>
        ''' <remarks></remarks>
        Public Shared Function Encrypt(ByVal passphrase As String, ByVal planeText As String) As String
            'プレーンテキストを暗号化されたBase６４文字列に変換
            Return System.Convert.ToBase64String(Encrypt(passphrase, System.Text.Encoding.UTF8.GetBytes(planeText)))
        End Function

        ''' <summary>
        ''' 文字列を復号化して暗号化文字列を返す
        ''' </summary>
        ''' <param name="passphrase">パスワード</param>
        ''' <param name="cryptText">データ文字列</param>
        ''' <returns>復号化された文字列</returns>
        ''' <remarks></remarks>
        Public Shared Function Decrypt(ByVal passphrase As String, ByVal cryptText As String) As String
            '暗号化されたBase６４文字列をプレーンテキストに変換
            Return System.Text.Encoding.UTF8.GetString(Decrypt(passphrase, System.Convert.FromBase64String(cryptText)))
        End Function

        ' Create a crypto key form a passphrase. This key is 
        ' used to encrypt and decrypt data.

        ''' <summary>
        ''' 暗号化キーのポインタを取得します
        ''' </summary>
        ''' <param name="hProv"></param>
        ''' <param name="passphrase"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetCryptoKey(ByVal hProv As IntPtr, ByVal passphrase As String) As IntPtr
            'ハンドル初期化
            Dim hHash As IntPtr = IntPtr.Zero
            Dim hKey As IntPtr = IntPtr.Zero

            Try
                '１２８ビットハッシュオブジェクトを生成
                If Not WinApi.CryptCreateHash(hProv, WinApi.CALG_MD5, IntPtr.Zero, 0, hHash) Then
                    Failed("CryptCreateHash")
                End If

                'ハッシュを暗号化します
                Dim keyData As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(passphrase)
                If Not WinApi.CryptHashData(hHash, keyData, CType(keyData.Length, Integer), 0) Then
                    Failed("CryptHashData")
                End If

                '暗号化ハッシュから４０ビットの暗号化キーを生成
                If Not WinApi.CryptDeriveKey(hProv, WinApi.CALG_RC2, hHash, WinApi.CRYPT_EXPORTABLE, hKey) Then
                    Failed("CryptDeriveKey")
                End If

            Finally
                'ハッシュオブジェクトを解放します
                If Not hHash.Equals(IntPtr.Zero) Then
                    WinApi.CryptDestroyHash(hHash)
                End If
            End Try

            Return hKey
        End Function


        ''' <summary>
        ''' エラー処理
        ''' </summary>
        ''' <param name="command"></param>
        ''' <remarks></remarks>
        Private Shared Sub Failed(ByVal command As String)
            Dim lastError As Integer = WinApi.GetLastError()
            Dim sb As New System.Text.StringBuilder(500)

            Try
                '最終エラーメッセージを取得
                WinApi.FormatMessage(WinApi.FORMAT_MESSAGE_FROM_SYSTEM, Nothing, lastError, 0, sb, 500, Nothing)
            Catch

                ' error calling FormatMessage
                sb.Append("N/A.")
            End Try

            Throw New SystemException( _
             String.Format("{0} failed." + ControlChars.Cr + ControlChars.Lf + _
             "Last error - 0x{1:x}." + ControlChars.Cr + ControlChars.Lf + _
             "Error message - {2}", command, lastError, sb.ToString()))
        End Sub

    End Class
End Class
