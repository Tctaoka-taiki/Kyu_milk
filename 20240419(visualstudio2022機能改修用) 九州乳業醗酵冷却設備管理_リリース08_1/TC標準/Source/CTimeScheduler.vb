''' <summary>
''' 時間スケジューラ
''' </summary>
''' <remarks></remarks>
Public Class CTimeScheduler
    Public Class Schedule

        ''' <summary>
        ''' 次回実行日時
        ''' </summary>
        ''' <remarks></remarks>
        Private _NextScheduleDate As Date
        Public Property NextScheduleDate() As Date
            Get
                Return _NextScheduleDate
            End Get
            Set(ByVal value As Date)
                _NextScheduleDate = value
            End Set
        End Property

        ''' <summary>
        ''' 実行済み日時
        ''' </summary>
        ''' <remarks></remarks>
        Private _BeforeScheduleDate As Date
        Public Property BeforeScheduleDate() As Date
            Get
                Return _BeforeScheduleDate
            End Get
            Set(ByVal value As Date)
                _BeforeScheduleDate = value
            End Set
        End Property

        ''' <summary>
        ''' タグ名
        ''' </summary>
        ''' <remarks></remarks>
        Private _Tag As String
        Public Property Tag() As String
            Get
                Return _Tag
            End Get
            Set(ByVal value As String)
                _Tag = value
            End Set
        End Property

        ''' <summary>
        ''' スケジュール実行間隔
        ''' </summary>
        ''' <remarks></remarks>
        Private _ScheduleSpan As TimeSpan
        Public Property ScheduleSpan() As TimeSpan
            Get
                Return _ScheduleSpan
            End Get
            Set(ByVal value As TimeSpan)
                _ScheduleSpan = value
            End Set
        End Property

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="NextScheduleDate"></param>
        ''' <param name="ScheduleSpan"></param>
        ''' <param name="Tag"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal NextScheduleDate As Date, ByVal ScheduleSpan As TimeSpan, Optional ByVal Tag As String = "")
            Me._NextScheduleDate = NextScheduleDate
            Me._ScheduleSpan = ScheduleSpan
            Me._Tag = Tag
        End Sub
    End Class

    ''' <summary>
    ''' 呼出元の同期コンテキスト
    ''' </summary>
    ''' <remarks></remarks>
    Private _sc As System.Threading.SynchronizationContext

    ''' <summary>
    ''' タイマー
    ''' </summary>
    ''' <remarks></remarks>
    Private _timer As New System.Timers.Timer

    ''' <summary>
    ''' スケジュール時間イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event Alarm(ByVal sender As Object, ByVal e As SchedulerEventArgs)

    ''' <summary>
    ''' スケジュールリスト
    ''' </summary>
    ''' <remarks></remarks>
    Private _ScheduleList As List(Of Schedule)
    Public Property ScheduleList() As List(Of Schedule)
        Get
            Return _ScheduleList
        End Get
        Set(ByVal value As List(Of Schedule))
            _ScheduleList = value
        End Set
    End Property

    ''' <summary>
    ''' コンストラクタ（監視間隔設定なしの場合は１秒）
    ''' </summary>
    ''' <remarks>Format(Now(),formatString)=compareStringの場合にコールバックされます</remarks>
    Public Sub New()
        Me.New(1000)
    End Sub

    ''' <summary>
    ''' コンストラクタ（監視間隔設定あり）
    ''' </summary>
    ''' <remarks>
    ''' このコンストラクタ呼び出し時の同期コンテキストを保持し、スケジュールイベント発生時に使用します。
    ''' Format(Now(),formatString)=compareStringの場合にコールバックされます</remarks>
    Public Sub New(ByVal Interval As Long)
        Me._timer.Interval = Interval
        AddHandler Me._timer.Elapsed, AddressOf Timer_Tick
        Me._ScheduleList = New List(Of Schedule)
        '呼び出し側の同期コンテキストを取得
        _sc = System.Threading.SynchronizationContext.Current
    End Sub

    ''' <summary>
    ''' アラームの有効／無効切替
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Enabled() As Boolean
        Get
            Return Me._timer.Enabled
        End Get
        Set(ByVal value As Boolean)
            Me._timer.Enabled = value
        End Set
    End Property

    ''' <summary>
    ''' タイマ割り込み
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        Dim dt As Date = Now()

        'スケジュールを比較
        For i As Integer = 0 To Me._ScheduleList.Count - 1
            With Me._ScheduleList(i)
                'NextScheduleDateを経過していない場合は以降の処理はしない()
                If .NextScheduleDate > dt Then
                    Continue For
                End If

                '実行済み日時がScheduleDateと同じであれば、未だ実行していないこと
                '実行済み日時がScheduleDateと異なれば
                If .BeforeScheduleDate < .NextScheduleDate Then
                    .BeforeScheduleDate = .NextScheduleDate
                    .NextScheduleDate = .NextScheduleDate.Add(.ScheduleSpan)
                    'デリゲートを呼び出し
                    _sc.Send(New System.Threading.SendOrPostCallback(AddressOf invAlarm), Me._ScheduleList(i))
                End If
            End With
        Next
    End Sub

    '呼び出し側のコンテキストでイベント発生
    Private Sub invAlarm(ByVal o As Object)
        RaiseEvent Alarm(Me, New SchedulerEventArgs(CType(o, Schedule)))
    End Sub

    ''' <summary>
    ''' スケジュールイベント
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SchedulerEventArgs
        Inherits EventArgs

        ''' <summary>
        ''' イベントの発生したスケジュール
        ''' </summary>
        ''' <remarks></remarks>
        Private _Schedule As Schedule
        Public Property Schedule() As Schedule
            Get
                Return _Schedule
            End Get
            Set(ByVal value As Schedule)
                _Schedule = value
            End Set
        End Property

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="schedule"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal schedule As Schedule)
            Me._Schedule = schedule
        End Sub
    End Class
End Class
