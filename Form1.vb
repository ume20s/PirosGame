Public Class Form1
    'PictureBoxコントロール配列のフィールドを作成
    Private Lblock() As System.Windows.Forms.PictureBox
    Private Rblock() As System.Windows.Forms.PictureBox

    Dim mm, ss As Integer           ' 時間計測用変数
    Dim Lnum, Rnum As Integer       ' ブロック数
    Dim LposX, LposY As Integer     ' ブロック座標
    Dim RposX, RposY As Integer
    Dim Lbt(12) As Integer          ' ブロック積層高度
    Dim Rbt(12) As Integer
    Dim r As New System.Random()    ' 乱数発生用
    Dim score As Integer            ' スコア

    ' もろもろの初期化
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer

        ' スコアの初期化
        score = 0
        ScoreLabel.Text = score.ToString.PadLeft(5, "0")

        ' 時間の初期化
        mm = 0
        ss = 0
        MinLabel.Text = mm
        If ss < 10 Then
            SecLabel.Text = "0" & ss
        Else
            SecLabel.Text = ss
        End If

        ' ブロックの初期化
        Me.Lblock = New System.Windows.Forms.PictureBox(100) {}
        Me.Rblock = New System.Windows.Forms.PictureBox(100) {}
        Lnum = 0
        Rnum = 0
        Lcreate(Lnum)
        Rcreate(Rnum)

        ' ブロックの積層高度の初期化
        For i = 0 To 12
            Lbt(i) = 480
            Rbt(i) = 480
        Next
    End Sub

    'よーいどん！
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim i As Integer

        For i = 0 To 100
            yoooi.Visible = True
            System.Threading.Thread.Sleep(10)
            System.Windows.Forms.Application.DoEvents()
        Next
        yoooi.Text = "どん！"
        For i = 0 To 50
            System.Threading.Thread.Sleep(10)
            System.Windows.Forms.Application.DoEvents()
        Next
        yoooi.Visible = False
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    ' 時間表示用タイマー
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ss = ss + 1
        If ss >= 60 Then
            mm = mm + 1
            ss = 0
        End If
        MinLabel.Text = mm
        SecLabel.Text = ss.ToString.ToString.PadLeft(2, "0")
    End Sub

    ' ブロック操作用タイマー
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim i As Integer

        ' 左移動
        LposY = LposY + 20
        Lblock(Lnum).Top = LposY

        ' 左底に着いたか判定
        If Lblock(Lnum).Width = 20 Then ' Iの処理
            If Lbt(LposX) <= Lblock(Lnum).Top + Lblock(Lnum).Height Then
                Lbt(LposX) = Lbt(LposX) - Lblock(Lnum).Height
                Lnum = Lnum + 1
                Lcreate(Lnum)
            End If
        Else                            ' PROSの処理
            If Lbt(LposX) <= Lblock(Lnum).Top + Lblock(Lnum).Height Then
                Lbt(LposX) = Lbt(LposX) - Lblock(Lnum).Height
                Lbt(LposX + 1) = Lbt(LposX)
                Lnum = Lnum + 1
                Lcreate(Lnum)
            ElseIf Lbt(LposX + 1) <= Lblock(Lnum).Top + Lblock(Lnum).Height Then
                Lbt(LposX + 1) = Lbt(LposX + 1) - Lblock(Lnum).Height
                Lbt(LposX) = Lbt(LposX + 1)
                Lnum = Lnum + 1
                Lcreate(Lnum)
            End If
        End If
        ' 右移動
        RposY = RposY + 20
        Rblock(Rnum).Top = RposY

        ' 右底に着いたか
        If Rblock(Rnum).Width = 20 Then ' Iの処理
            If Rbt(RposX) <= Rblock(Rnum).Top + Rblock(Rnum).Height Then
                Rbt(RposX) = Rbt(RposX) - Rblock(Rnum).Height
                Rnum = Rnum + 1
                Rcreate(Rnum)
                score = score + 10
                ScoreLabel.Text = score.ToString.PadLeft(5, "0")
            End If
        Else                            ' PROSの処理
            If Rbt(RposX) <= Rblock(Rnum).Top + Rblock(Rnum).Height Then
                Rbt(RposX) = Rbt(RposX) - Rblock(Rnum).Height
                Rbt(RposX + 1) = Rbt(RposX)
                Rnum = Rnum + 1
                Rcreate(Rnum)
                score = score + 20
                ScoreLabel.Text = score.ToString.PadLeft(5, "0")
            ElseIf Rbt(RposX + 1) <= Rblock(Rnum).Top + Rblock(Rnum).Height Then
                Rbt(RposX + 1) = Rbt(RposX + 1) - Rblock(Rnum).Height
                Rbt(RposX) = Rbt(RposX + 1)
                Rnum = Rnum + 1
                Rcreate(Rnum)
                score = score + 20
                ScoreLabel.Text = score.ToString.PadLeft(5, "0")
            End If
        End If

        ' 終了判定
        For i = 0 To 12
            If Lbt(i) <= 10 Then
                Ending(1)
            End If
        Next
        For i = 0 To 12
            If Rbt(i) <= 10 Then
                Ending(2)
            End If
        Next
    End Sub

    ' 左ブロック生成
    Private Sub Lcreate(num)
        ' インスタンス生成
        Me.Lblock(num) = New System.Windows.Forms.PictureBox
        ' 生成ブロック決定
        Select Case r.Next(5)
            Case 0  ' P
                Me.Lblock(num).Image = My.Resources.P
                Me.Lblock(num).Size = New Size(40, 60)
            Case 1  ' I
                Me.Lblock(num).Image = My.Resources.I
                Me.Lblock(num).Size = New Size(20, 60)
            Case 2  ' R
                Me.Lblock(num).Image = My.Resources.R
                Me.Lblock(num).Size = New Size(40, 60)
            Case 3  ' O
                Me.Lblock(num).Image = My.Resources.O
                Me.Lblock(num).Size = New Size(40, 60)
            Case Else  ' S
                Me.Lblock(num).Image = My.Resources.P
                Me.Lblock(num).Size = New Size(40, 60)
        End Select
        LposX = r.Next(11)
        LposY = -60
        Me.Lblock(num).Location = New Point(LposX * 20, LposY)
        'フォームにコントロールを追加
        Panel1.Controls.Add(Lblock(num))
    End Sub

    ' 右ブロック生成
    Private Sub Rcreate(num)
        ' インスタンス生成
        Me.Rblock(num) = New System.Windows.Forms.PictureBox
        ' 生成ブロック決定
        Select Case r.Next(5)
            Case 0  ' P
                Me.Rblock(num).Image = My.Resources.P
                Me.Rblock(num).Size = New Size(40, 60)
            Case 1  ' I
                Me.Rblock(num).Image = My.Resources.I
                Me.Rblock(num).Size = New Size(20, 60)
            Case 2  ' R
                Me.Rblock(num).Image = My.Resources.R
                Me.Rblock(num).Size = New Size(40, 60)
            Case 3  ' O
                Me.Rblock(num).Image = My.Resources.O
                Me.Rblock(num).Size = New Size(40, 60)
            Case Else  ' S
                Me.Rblock(num).Image = My.Resources.S
                Me.Rblock(num).Size = New Size(40, 60)
        End Select
        RposX = r.Next(11)
        RposY = -60
        Me.Rblock(num).Location = New Point(RposX * 20, RposY)
        'フォームにコントロールを追加
        Panel2.Controls.Add(Rblock(num))
    End Sub

    ' エンディング（引数が１だったら右が勝利）
    Private Sub Ending(win As Integer)
        Dim i, j As Integer
        Dim vec As Integer

        Timer1.Enabled = False
        Timer2.Enabled = False
        vec = -20
        If win = 1 Then
            Lend1.Image = My.Resources.zannen
            Lend2.Image = My.Resources.pirosuke
            Rend1.Image = My.Resources.yattane
            Rend2.Image = My.Resources.yuimarl
            For i = 0 To 50
                For j = 0 To Lnum
                    Lblock(j).Top = Lblock(j).Top + vec
                Next
                System.Threading.Thread.Sleep(12)
                vec = vec + 1
            Next
        Else
            Lend1.Image = My.Resources.yattane
            Lend2.Image = My.Resources.yuimarl
            Rend1.Image = My.Resources.zannen
            Rend2.Image = My.Resources.pirosuke
            For i = 0 To 50
                For j = 0 To Rnum
                    Rblock(j).Top = Rblock(j).Top + vec
                Next
                System.Threading.Thread.Sleep(12)
                vec = vec + 1
            Next
        End If
        Lend1.Visible = True
        Lend2.Visible = True
        Rend1.Visible = True
        Rend2.Visible = True
    End Sub

    ' キー入力で移動
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Left Then       ' 左矢印キー
            RposX = RposX - 1
            If RposX <= 0 Then
                RposX = 0
            End If
        ElseIf e.KeyCode = Keys.Right Then  ' 右矢印キー
            RposX = RposX + 1
            If Rblock(Rnum).Width = 20 Then
                If RposX >= 11 Then
                    RposX = 11
                End If
            Else
                If RposX >= 10 Then
                    RposX = 10
                End If
            End If
        End If
        Me.Rblock(Rnum).Location = New Point(RposX * 20, RposY)
    End Sub
End Class
