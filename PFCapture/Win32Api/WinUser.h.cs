using System;
using System.Runtime.InteropServices;

namespace Win32Api
{
    public static partial class User32
    {
        /// <summary>
        /// クリップボードビューアのチェインから、指定されたウィンドウを削除します。
        /// </summary>
        /// <param name="hWndRemove">クリップボードビューアのチェインから削除したいウィンドウのハンドルを指定します。以前に SetClipboardViewer 関数に渡したハンドルでなければなりません。</param>
        /// <param name="hWndNewNext">クリップボードビューアのチェイン内で hWndRemove ウィンドウの次に存在するウィンドウのハンドルを指定します。このハンドルは、SetClipboardViewer 関数の戻り値です。ただし、 メッセージによりクリップボードビューアのチェインが変更された場合は、その限りではありません。クリップボードビューアのチェインが変更されるとこのメッセージが送信されるので、このメッセージを監視して、常に次のウィンドウを把握してください。</param>
        /// <returns>クリップボードビューアチェイン内のウィンドウに WM_CHANGECBCHAIN メッセージを渡した結果を示す値が返ります。クリップボードビューアチェイン内のウィンドウは、WM_CHANGECBCHAIN メッセージを処理すると、一般的には、0（FALSE）を返します。そのため、ChangeClipboardChain 関数の戻り値は、一般的には、0（FALSE）になります。クリップボードビューアチェイン内に、ウィンドウが 1 つしかなかったときの戻り値は、一般的に、0 以外の値（TRUE）になります。</returns>
        [DllImport(AssemblyName)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        /// <summary>
        /// 1 つまたは複数のウィンドウへ、指定されたメッセージを送信します。この関数は、指定されたウィンドウのウィンドウプロシージャを呼び出し、そのウィンドウプロシージャがメッセージを処理し終わった後で、制御を返します。
        /// <para>メッセージを送信して即座に制御を返すには、SendMessageCallback または SendNotifyMessage 関数を使ってください。メッセージを 1 つのスレッドのメッセージキューにポストして即座に制御を返すには、PostMessage または PostThreadMessage 関数を使ってください。</para>
        /// </summary>
        /// <param name="hWnd">1 つのウィンドウのハンドルを指定します。このウィンドウのウィンドウプロシージャがメッセージを受信します。HWND_BROADCAST を指定すると、この関数は、システム内のすべてのトップレベルウィンドウ（親を持たないウィンドウ）へメッセージを送信します。無効になっている所有されていないウィンドウ、不可視の所有されていないウィンドウ、オーバーラップされた（手前にほかのウィンドウがあって覆い隠されている）ウィンドウ、ポップアップウィンドウも送信先になります。子ウィンドウへはメッセージを送信しません。</param>
        /// <param name="Msg">送信するべきメッセージを指定します。</param>
        /// <param name="wParam">メッセージ特有の追加情報を指定します。</param>
        /// <param name="lParam">メッセージ特有の追加情報を指定します。</param>
        /// <returns>メッセージ処理の結果が返ります。この戻り値の意味は、送信されたメッセージにより異なります。</returns>
        [DllImport(AssemblyName)]
        public static extern int PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// クリップボードビューアのチェインに、指定されたウィンドウを追加します。クリップボードの内容が変更されると必ず、クリップボードビューアの各ウィンドウは WM_DRAWCLIPBOARD メッセージを受け取ります。
        /// </summary>
        /// <param name="hWndNewViewer">クリップボードのチェインに追加したいウィンドウのハンドルを指定します。</param>
        /// <returns>関数が成功すると、クリップボードビューアのチェイン内で、追加したウィンドウの次に位置するウィンドウのハンドルが返ります。エラーが発生した場合、または、クリップボードビューアのチェイン内に他のウィンドウが存在しなかった場合は、NULL が返ります。拡張エラー情報を取得するには、 関数を使います。</returns>
        [DllImport("user32")]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
    }

    public enum WM : uint
    {
        CUT = 0x0300,
        COPY = 0x0301,
        PASTE = 0x0302,
        CLEAR = 0x0303,
        UNDO = 0x0304,
        RENDERFORMAT = 0x0305,
        RENDERALLFORMATS = 0x0306,
        DESTROYCLIPBOARD = 0x0307,
        DRAWCLIPBOARD = 0x0308,
        PAINTCLIPBOARD = 0x0309,
        VSCROLLCLIPBOARD = 0x030A,
        SIZECLIPBOARD = 0x030B,
        ASKCBFORMATNAME = 0x030C,
        CHANGECBCHAIN = 0x030D,
        HSCROLLCLIPBOARD = 0x030E,
        QUERYNEWPALETTE = 0x030F,
        PALETTEISCHANGING = 0x0310,
        PALETTECHANGED = 0x0311,
        HOTKEY = 0x0312
    }
}
