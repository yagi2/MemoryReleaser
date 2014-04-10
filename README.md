MemoryReleaser
==========
![ScreenShot](/screenshots/ss_001.png)

新旧比較
![ScreenShot](/screenshots/ss_002.png)

[Windows Server 2003 Resource Kit Tools](http://www.microsoft.com/en-us/download/details.aspx?displaylang=en&id=17657)に含まれるempty.exeを利用してWindowsPCのメモリを開放するサポートツールです。
基本的には[MemoryFree](https://github.com/yagi2/MemoryFree)と同じです。
MemoryFreeの動作をするちょっとスタイリッシュになった感じのWPFアプリケーションです。

empty.exeに関しての詳しい使い方は，[Microsoftの公式メモリ解放ソフト[empty.exe]を使用してWindowsのメモリを解放する](http://blog.yagi2.com/?p=429#more-429)に記述しましたので御覧ください。

### 機能
* empty.exeを利用してメモリの解放

### 今後実装するもの
* PIDを指定してのメモリの解放
* イメージ名を指定してのメモリの解放
* 解放前後の物理メモリ量の表示
* ちょっとした隠し機能

### 動作環境（確認済み）
* Windows 7

### 簡単な使い方の説明
詳しい使い方は[Microsoftの公式メモリ解放ソフト[empty.exe]を使用してWindowsのメモリを解放する](http://blog.yagi2.com/?p=429#more-429)のコピーする手順まで踏んでいただければ結構です。

* [Windows Server 2003 Resource Kit Tools](http://www.microsoft.com/en-us/download/details.aspx?displaylang=en&id=17657)をDLする。
* インストール，もしくはWinRARなどで.msiの中身を取り出す。
* 中身にあるempty.exeを C:\WINDOWS\system32 にコピーします。
* あとはMemoryFree.exeを起動して解放するだけです。

#### 隠し機能
* これもMemoryFreeと同じような隠し機能をもっと隠した感じで実装する予定です。

#### 実装予定
* 隠し機能のフォームを呼んだ時点でディスクトレイが開いているのか開いているのかを取得してボタンのEnabledを設定する。

#### ライセンス
* MIT License
MITライセンスの元で公開するオープンソース，ソフトウェアです。詳しくはLICENSE.txtを御覧ください。
