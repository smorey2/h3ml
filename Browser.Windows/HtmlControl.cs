using H3ml.Layout;
using System.Drawing;
using System.Windows.Forms;

namespace Browser.Windows
{
    public partial class HtmlControl : UserControl
    {
        int _max_top;
        int _max_left;
        context _context;
        Webhistory _history;
        WebpageControl _page;
        WebpageControl _page_next;

        public HtmlControl()
        {
            InitializeComponent();
        }

        public void create(context context) => _context = context;

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    using (var cr = CreateGraphics())
        //    {
        //        var rect = cr.VisibleClipBounds;
        //        var pos = new position
        //        {
        //            width = (int)rect.Width,
        //            height = (int)rect.Height,
        //            x = (int)rect.X,
        //            y = (int)rect.Y
        //        };
        //        if (_doc != null)
        //            _doc.draw(cr, 0, 0, 0, pos);
        //    }
        //}

        //protected override void OnResize(EventArgs e)
        //{
        //    if (_html != null && _rendered_width != Width)
        //    {
        //        _rendered_width = Width;
        //        _html.media_changed();
        //        _html.render(_rendered_width);
        //        //set_size_request(_html.width, _html.height);
        //        Refresh();
        //    }
        //}

        public context get_html_context() => _context;

        public void open(string url, bool reload = false)
        {
            string hash = null;
            var hash_pos = url.IndexOf('#');
            if (hash_pos != -1)
            {
                hash = url.Substring(hash_pos + 1);
                url.Remove(hash_pos);
            }
            var open_hash_only = false;
            lock (this)
            {
                if (_page != null)
                {
                    if (_page._url == url && !reload) open_hash_only = true;
                    else _page._http.Stop();
                }
                if (!open_hash_only)
                {
                    if (_page_next != null)
                    {
                        _page_next._http.Stop();
                        Controls.Remove(_page_next); _page_next.Dispose();
                    }
                    _page_next = new WebpageControl(); Controls.Add(_page_next);
                    _page_next._hash = hash;
                    _page_next.load(url);
                }
            }
            if (open_hash_only)
            {
                show_hash(hash);
                update_scroll();
                redraw(Rectangle.Empty, false);
                update_history();
            }
        }

        public void render(bool calc_time = false, bool do_redraw = true, int calc_repeat = 1)
        {
            var page = get_page();
            if (page == null)
                return;
            //RECT rcClient;
            //GetClientRect(m_hWnd, &rcClient);
            //var width = rcClient.right - rcClient.left;
            //var height = rcClient.bottom - rcClient.top;
            //if (calc_time)
            //{
            //    if (calc_repeat <= 0) calc_repeat = 1;
            //    var tic1 = GetTickCount();
            //    for (var i = 0; i < calc_repeat; i++)
            //        page._doc.render(width);
            //    var tic2 = GetTickCount();
            //    WCHAR msg[255];
            //    StringCchPrintf(msg, 255, L"Render time: %d msec", tic2 - tic1);
            //    MessageBox(m_hWnd, msg, L"litebrowser", MB_ICONINFORMATION | MB_OK);
            //}
            //else
            //    page._doc.render(width);

            //_max_top = page._doc.height - height;
            //if (_max_top < 0) _max_top = 0;
            //_max_left = page._doc->width - width;
            //if (_max_left < 0) _max_left = 0;
            //if (do_redraw)
            //{
            //    update_scroll();
            //    redraw(NULL, FALSE);
            //}
        }

        void redraw(Rectangle rcDraw, bool update)
        {
            Invalidate(rcDraw, true);
            if (update)
                Update();
        }

        void update_scroll()
        {
            //if (!is_valid_page())
            //{
            //    ShowScrollBar(m_hWnd, SB_BOTH, FALSE);
            //    return;
            //}

            //if (m_max_top > 0)
            //{
            //    ShowScrollBar(m_hWnd, SB_VERT, TRUE);

            //    RECT rcClient;
            //    GetClientRect(m_hWnd, &rcClient);

            //    SCROLLINFO si;
            //    si.cbSize = sizeof(SCROLLINFO);
            //    si.fMask = SIF_ALL;
            //    si.nMin = 0;
            //    si.nMax = m_max_top + (rcClient.bottom - rcClient.top);
            //    si.nPos = m_top;
            //    si.nPage = rcClient.bottom - rcClient.top;
            //    SetScrollInfo(m_hWnd, SB_VERT, &si, TRUE);
            //}
            //else
            //{
            //    ShowScrollBar(m_hWnd, SB_VERT, FALSE);
            //}

            //if (m_max_left > 0)
            //{
            //    ShowScrollBar(m_hWnd, SB_HORZ, TRUE);

            //    RECT rcClient;
            //    GetClientRect(m_hWnd, &rcClient);

            //    SCROLLINFO si;
            //    si.cbSize = sizeof(SCROLLINFO);
            //    si.fMask = SIF_ALL;
            //    si.nMin = 0;
            //    si.nMax = m_max_left + (rcClient.right - rcClient.left);
            //    si.nPos = m_left;
            //    si.nPage = rcClient.right - rcClient.left;
            //    SetScrollInfo(m_hWnd, SB_HORZ, &si, TRUE);
            //}
            //else
            //{
            //    ShowScrollBar(m_hWnd, SB_HORZ, FALSE);
            //}
        }

        //void OnVScroll(int pos, int flags)
        //{
        //    RECT rcClient;
        //    GetClientRect(m_hWnd, &rcClient);

        //    int lineHeight = 16;
        //    int pageHeight = rcClient.bottom - rcClient.top - lineHeight;

        //    int newTop = m_top;

        //    switch (flags)
        //    {
        //        case SB_LINEDOWN:
        //            newTop = m_top + lineHeight;
        //            if (newTop > m_max_top)
        //            {
        //                newTop = m_max_top;
        //            }
        //            break;
        //        case SB_PAGEDOWN:
        //            newTop = m_top + pageHeight;
        //            if (newTop > m_max_top)
        //            {
        //                newTop = m_max_top;
        //            }
        //            break;
        //        case SB_LINEUP:
        //            newTop = m_top - lineHeight;
        //            if (newTop < 0)
        //            {
        //                newTop = 0;
        //            }
        //            break;
        //        case SB_PAGEUP:
        //            newTop = m_top - pageHeight;
        //            if (newTop < 0)
        //            {
        //                newTop = 0;
        //            }
        //            break;
        //        case SB_THUMBPOSITION:
        //        case SB_THUMBTRACK:
        //            newTop = pos;
        //            if (newTop < 0)
        //            {
        //                newTop = 0;
        //            }
        //            if (newTop > m_max_top)
        //            {
        //                newTop = m_max_top;
        //            }
        //            break;
        //    }
        //    scroll_to(m_left, newTop);
        //}

        //void OnHScroll(int pos, int flags)
        //{
        //RECT rcClient;
        //GetClientRect(m_hWnd, &rcClient);

        //int lineWidth = 16;
        //int pageWidth = rcClient.right - rcClient.left - lineWidth;

        //int newLeft = m_left;

        //switch (flags)
        //{
        //    case SB_LINERIGHT:
        //        newLeft = m_left + lineWidth;
        //        if (newLeft > m_max_left)
        //        {
        //            newLeft = m_max_left;
        //        }
        //        break;
        //    case SB_PAGERIGHT:
        //        newLeft = m_left + pageWidth;
        //        if (newLeft > m_max_left)
        //        {
        //            newLeft = m_max_left;
        //        }
        //        break;
        //    case SB_LINELEFT:
        //        newLeft = m_left - lineWidth;
        //        if (newLeft < 0)
        //        {
        //            newLeft = 0;
        //        }
        //        break;
        //    case SB_PAGELEFT:
        //        newLeft = m_left - pageWidth;
        //        if (newLeft < 0)
        //        {
        //            newLeft = 0;
        //        }
        //        break;
        //    case SB_THUMBPOSITION:
        //    case SB_THUMBTRACK:
        //        newLeft = pos;
        //        if (newLeft < 0)
        //        {
        //            newLeft = 0;
        //        }
        //        if (newLeft > m_max_left)
        //        {
        //            newLeft = m_max_left;
        //        }
        //        break;
        //}

        //scroll_to(newLeft, m_top);
        //}

        //readonly int WHEEL_DELTA = SystemInformation.MouseWheelScrollDelta;
        //void OnMouseWheel(int delta)
        //{
        //    var lineHeight = 16;
        //    var newTop = Top - delta / WHEEL_DELTA * lineHeight * 3;
        //    if (newTop < 0)
        //        newTop = 0;
        //    if (newTop > _max_top)
        //        newTop = _max_top;
        //    if (newTop != Top)
        //        scroll_to(Left, newTop);
        //}

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.F5: refresh(); break;
                //case Keys.Next: OnVScroll(0, SB_PAGEDOWN);  break;
                //case Keys.Prior: OnVScroll(0, SB_PAGEUP); break;
                //case Keys.Down: OnVScroll(0, SB_LINEDOWN); break;
                //case Keys.Up: OnVScroll(0, SB_LINEUP); break;
                //case Keys.Home: scroll_to(_left, 0); break;
                //case Keys.End: scroll_to(_left, _max_top; break;
                //case Keys.Left: OnHScroll(0, SB_LINELEFT); break;
                //case Keys.Right: OnHScroll(0, SB_LINERIGHT); ; break;
            }
            base.OnKeyDown(e);
        }

        public void refresh()
        {
            var page = get_page();
            if (page == null)
                return;
            open(page._url, true);
        }

        void set_caption()
        {
            var page = get_page();
            Parent.Text = page?._caption ?? "litebrowser";
        }

        void OnMouseMove(int x, int y)
        {
            var page = get_page();
            if (page == null)
                return;
            //litehtml::position::vector redraw_boxes;
            //if (page->m_doc->on_mouse_over(x + m_left, y + m_top, x, y, redraw_boxes))
            //{
            //    for (litehtml::position::vector::iterator box = redraw_boxes.begin(); box != redraw_boxes.end(); box++)
            //    {
            //        box->x -= m_left;
            //        box->y -= m_top;
            //        RECT rcRedraw;
            //        rcRedraw.left = box->left();
            //        rcRedraw.right = box->right();
            //        rcRedraw.top = box->top();
            //        rcRedraw.bottom = box->bottom();
            //        redraw(&rcRedraw, FALSE);
            //    }
            //    UpdateWindow(m_hWnd);
            //    update_cursor();
            //}
        }

        void OnMouseLeave()
        {
            var page = get_page();
            if (page == null)
                return;
            //litehtml::position::vector redraw_boxes;
            //if (page->m_doc->on_mouse_leave(redraw_boxes))
            //{
            //    for (litehtml::position::vector::iterator box = redraw_boxes.begin(); box != redraw_boxes.end(); box++)
            //    {
            //        box->x -= m_left;
            //        box->y -= m_top;
            //        RECT rcRedraw;
            //        rcRedraw.left = box->left();
            //        rcRedraw.right = box->right();
            //        rcRedraw.top = box->top();
            //        rcRedraw.bottom = box->bottom();
            //        redraw(&rcRedraw, FALSE);
            //    }
            //    UpdateWindow(m_hWnd);
            //}
        }

        void OnLButtonDown(int x, int y)
        {
            var page = get_page();
            if (page == null)
                return;
            //litehtml::position::vector redraw_boxes;
            //if (page->m_doc->on_lbutton_down(x + m_left, y + m_top, x, y, redraw_boxes))
            //{
            //    for (litehtml::position::vector::iterator box = redraw_boxes.begin(); box != redraw_boxes.end(); box++)
            //    {
            //        box->x -= m_left;
            //        box->y -= m_top;
            //        RECT rcRedraw;
            //        rcRedraw.left = box->left();
            //        rcRedraw.right = box->right();
            //        rcRedraw.top = box->top();
            //        rcRedraw.bottom = box->bottom();
            //        redraw(&rcRedraw, FALSE);
            //    }
            //    UpdateWindow(m_hWnd);
            //}
        }

        void OnLButtonUp(int x, int y)
        {
            var page = get_page();
            if (page == null)
                return;
            //litehtml::position::vector redraw_boxes;
            //if (page->m_doc->on_lbutton_up(x + m_left, y + m_top, x, y, redraw_boxes))
            //{
            //    for (litehtml::position::vector::iterator box = redraw_boxes.begin(); box != redraw_boxes.end(); box++)
            //    {
            //        box->x -= m_left;
            //        box->y -= m_top;
            //        RECT rcRedraw;
            //        rcRedraw.left = box->left();
            //        rcRedraw.right = box->right();
            //        rcRedraw.top = box->top();
            //        rcRedraw.bottom = box->bottom();
            //        redraw(&rcRedraw, FALSE);
            //    }
            //    UpdateWindow(m_hWnd);
            //}
        }

        public void back()
        {
            if (_history.back(out var url))
                open(url, false);
        }

        public void forward()
        {
            if (_history.forward(out var url))
                open(url, false);
        }

        void update_cursor()
        {
            var defArrow = _page_next != null ? Cursors.AppStarting : Cursors.Default; //Cursors.Arrow;
            var page = get_page();
            Cursor = page == null ? defArrow : page._cursor == "pointer" ? Cursors.Hand : defArrow;
        }

        public void get_client_rect(out position client) => client = new position
        {
            x = Left,
            y = Top,
            width = Width,
            height = Height,
        };

        bool is_valid_page(bool with_lock = true)
        {
            if (with_lock)
                lock (this)
                    return !(_page == null || (_page != null && _page._doc == null));
            return !(_page == null || (_page != null && _page._doc == null));
        }

        WebpageControl get_page(bool with_lock = true)
        {
            if (with_lock)
                lock (this)
                    return is_valid_page(false) ? _page : null;
            return is_valid_page(false) ? _page : null;
        }

        void OnPageReady()
        {
            string url = null;
            WebpageControl page;
            lock (this)
                page = _page_next;
            string hash = null;
            var is_ok = false;
            lock (this)
                if (_page_next != null)
                {
                    _page = _page_next;
                    _page_next = null;
                    is_ok = true;
                    hash = _page._hash;
                    url = _page._url;
                }
            if (is_ok)
            {
                render(false, false);
                Top = 0;
                Left = 0;
                show_hash(hash);
                update_scroll();
                redraw(Rectangle.Empty, false);
                set_caption();
                update_history();
                ((_browser)Parent).on_page_loaded(url);
            }
        }

        void show_hash(string hash)
        {
            var page = get_page();
            if (page == null)
                return;
            //            if (!hash.empty())
            //            {
            //                litehtml::tchar_t selector[255];
            //# ifndef LITEHTML_UTF8
            //                StringCchPrintf(selector, 255, L"#%s", hash.c_str());
            //#else
            //                LPSTR hashA = cairo_font::wchar_to_utf8(hash.c_str());
            //                StringCchPrintfA(selector, 255, "#%s", hashA);
            //#endif
            //                element::ptr el = page->m_doc->root()->select_one(selector);
            //                if (!el)
            //                {
            //# ifndef LITEHTML_UTF8
            //                    StringCchPrintf(selector, 255, L"[name=%s]", hash.c_str());
            //#else
            //                    StringCchPrintfA(selector, 255, "[name=%s]", hashA);
            //#endif
            //                    el = page->m_doc->root()->select_one(selector);
            //                }
            //                if (el)
            //                {
            //                    litehtml::position pos = el->get_placement();
            //                    m_top = pos.y;
            //                }
            //# ifdef LITEHTML_UTF8
            //                delete hashA;
            //#endif
            //            }
            //            else
            //            {
            //                m_top = 0;
            //            }
            //            if (page->m_hash != hash)
            //            {
            //                page->m_hash = hash;
            //            }
        }

        void update_history()
        {
            var page = get_page();
            if (page == null)
                return;
            page.get_url(out var url);
            _history.url_opened(url);
        }

        void scroll_to(int new_left, int new_top)
        {
            //position client;
            //get_client_rect(client);

            //var need_redraw = false;
            //if (new_top != Top)
            //{
            //    if (Math.Abs(new_top - Top) < client.height - client.height / 4)
            //    {
            //        RECT rcRedraw;
            //        if (new_top > m_top)
            //        {
            //            int lines_count = new_top - m_top;
            //            int rgba_to_scroll = m_dib.width() * lines_count;
            //            int rgba_total = m_dib.width() * client.height;

            //            memmove(m_dib.bits(), m_dib.bits() + rgba_to_scroll, (rgba_total - rgba_to_scroll) * sizeof(RGBQUAD));
            //            rcRedraw.left = client.left();
            //            rcRedraw.right = client.right();
            //            rcRedraw.top = client.height - lines_count;
            //            rcRedraw.bottom = client.height;
            //        }
            //        else
            //        {
            //            int lines_count = m_top - new_top;
            //            int rgba_to_scroll = m_dib.width() * lines_count;
            //            int rgba_total = m_dib.width() * client.height;

            //            memmove(m_dib.bits() + rgba_to_scroll, m_dib.bits(), (rgba_total - rgba_to_scroll) * sizeof(RGBQUAD));
            //            rcRedraw.left = client.left();
            //            rcRedraw.right = client.right();
            //            rcRedraw.top = client.top();
            //            rcRedraw.bottom = lines_count;
            //        }

            //        int old_top = m_top;
            //        m_top = new_top;
            //        OnPaint(&m_dib, &rcRedraw);

            //        litehtml::position::vector fixed_boxes;

            //        lock () ;
            //        web_page* page = get_page(false);
            //        if (page)
            //        {
            //            page->m_doc->get_fixed_boxes(fixed_boxes);
            //            page->release();
            //        }
            //        unlock();

            //        if (!fixed_boxes.empty())
            //        {
            //            RECT rcFixed;
            //            RECT rcClient;
            //            rcClient.left = client.left();
            //            rcClient.right = client.right();
            //            rcClient.top = client.top();
            //            rcClient.bottom = client.bottom();

            //            for (litehtml::position::vector::iterator iter = fixed_boxes.begin(); iter != fixed_boxes.end(); iter++)
            //            {
            //                rcRedraw.left = iter->left();
            //                rcRedraw.right = iter->right();
            //                rcRedraw.top = iter->top();
            //                rcRedraw.bottom = iter->bottom();
            //                if (IntersectRect(&rcFixed, &rcRedraw, &rcClient))
            //                {
            //                    OnPaint(&m_dib, &rcFixed);
            //                }

            //                rcRedraw.left = iter->left();
            //                rcRedraw.right = iter->right();
            //                rcRedraw.top = iter->top() + (old_top - m_top);
            //                rcRedraw.bottom = iter->bottom() + (old_top - m_top);

            //                if (IntersectRect(&rcFixed, &rcRedraw, &rcClient))
            //                {
            //                    OnPaint(&m_dib, &rcFixed);
            //                }
            //            }
            //        }

            //        HDC hdc = GetDC(m_hWnd);

            //        BitBlt(hdc, client.left(), client.top(),
            //            client.width,
            //            client.height, m_dib, 0, 0, SRCCOPY);

            //        ReleaseDC(m_hWnd, hdc);

            //    }
            //    else
            //    {
            //        need_redraw = true;
            //    }

            //    m_top = new_top;
            //    SetScrollPos(m_hWnd, SB_VERT, m_top, TRUE);
            //}


            //if (new_left != m_left)
            //{
            //    m_left = new_left;
            //    SetScrollPos(m_hWnd, SB_HORZ, m_left, TRUE);
            //    need_redraw = true;
            //}

            //if (need_redraw)
            //{
            //    redraw(NULL, TRUE);
            //}
        }
    }
}
