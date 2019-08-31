using System;
using System.Collections.Generic;
using UnityEngine;

namespace H3ml.Layout.Containers
{
    public class container_unity : MonoBehaviour, Icontainer
    {
        readonly Dictionary<string, object> _images = new Dictionary<string, object>();
        readonly List<position> _clips = new List<position>();

        public virtual void get_client_rect(out position client) => throw new NotImplementedException();
        public virtual void import_css(out string text, string url, ref string baseurl) => throw new NotImplementedException();
        public virtual void on_anchor_click(string url, element el) => throw new NotImplementedException();
        public string resolve_color(string color) => null;
        public virtual void set_base_url(string base_url) => throw new NotImplementedException();
        public virtual void set_caption(string caption) => throw new NotImplementedException();
        public virtual void set_cursor(string cursor) => throw new NotImplementedException();
        protected virtual object get_image(string url, bool redraw_on_ready) => throw new NotImplementedException();

        public void Refresh() { }

        public object create_font(string faceName, int size, int weight, font_style italic, uint decoration, out font_metrics fm)
        {
            fm = default(font_metrics);
            var fonts = new List<string>();
            html.split_string(faceName, fonts, ",");
            fonts[0].Trim();
            var fnt = Font.CreateDynamicFontFromOSFont(fonts[0], size);
            fm.ascent = fnt.ascent;
            fm.descent = 0;
            fm.x_height = fm.height = fnt.lineHeight;
            fm.draw_spaces = italic == font_style.italic || decoration != 0;
            return null;
        }

        public void delete_font(object hFont) { }

        public int text_width(string text, object hFont)
        {
            var font = (Font)hFont;
            var width = 0;
            foreach (var c in text.ToCharArray())
            {
                font.GetCharacterInfo(c, out var characterInfo, font.fontSize);
                width += characterInfo.advance;
            }
            return width;
        }

        public void draw_text(object hdc, string text, object hFont, web_color color, position pos)
        {
            var root = (GameObject)hdc;
            var obj = new GameObject("Text");
            obj.transform.SetParent(root.transform);
            obj.transform.position = new Vector3(pos.left, pos.top, pos.depth);
            //
            var font = (Font)hFont;
            var textMesh = obj.AddComponent<TextMesh>();
            textMesh.font = font;
            textMesh.text = text;
            textMesh.color = new Color(color.red, color.green, color.blue);
            var mat = obj.GetComponent<MeshRenderer>().material;
            mat.mainTexture = font.material.mainTexture;
            mat.shader = Shader.Find("GUI/3D Text Shader");
        }

        public int pt_to_px(int pt) => pt * 96 / 72;

        public int get_default_font_size() => 16;

        public void draw_list_marker(object hdc, list_marker marker)
        {
        }

        public void load_image(string src, string baseurl, bool redraw_on_ready)
        {
            make_url(src, baseurl, out var url);
            if (!_images.ContainsKey(url))
            {
                var img = get_image(url, redraw_on_ready);
                if (img != null)
                    _images[url] = img;
            }
        }

        public void get_image_size(string src, string baseurl, out size sz)
        {
            sz = new size();
            make_url(src, baseurl, out var url);
            if (_images.TryGetValue(url, out var img) && img is Texture tex)
            {
                sz.width = tex.width;
                sz.height = tex.height;
            }
        }

        public void draw_image(object hdc, string src, string baseurl, position pos)
        {
            make_url(src, baseurl, out var url);
            if (_images.TryGetValue(url, out var img) && img is Texture tex)
                draw_bmp(hdc, tex, pos);
        }

        void draw_bmp(object hdc, Texture tex, position pos)
        {
            var root = (GameObject)hdc;
            var obj = GameObject.CreatePrimitive(PrimitiveType.Quad);
            obj.transform.SetParent(root.transform);
            obj.transform.position = new Vector3(pos.left, pos.top, pos.depth);
            //
            var mat = obj.GetComponent<MeshRenderer>().material;
            mat.shader = Shader.Find("UI/Default");
            mat.mainTexture = tex;
            var ratio = tex.height / (float)tex.width;
            var x = 5.0F;
            var y = x * ratio;
            obj.transform.localScale = new Vector3(x, y, 1);
        }

        public void draw_background(object hdc, background_paint bg)
        {
            make_url(bg.image, bg.baseurl, out var url);
            if (_images.TryGetValue(url, out var img) && img is GameObject bmp)
                draw_img_bg(hdc, bmp, bg);
        }

        protected void draw_img_bg(object hdc, GameObject bmp, background_paint bg)
        {
        }

        protected virtual void make_url(string url, string basepath, out string urlout) => urlout = url;

        public void draw_borders(object hdc, borders borders, position draw_pos, bool root = false)
        {
        }

        public void transform_text(string text, text_transform tt) { }

        public void set_clip(position pos, border_radiuses bdr_radius, bool valid_x, bool valid_y)
        {
            var clip_pos = pos;
            get_client_rect(out var client_pos);
            if (!valid_x)
            {
                clip_pos.x = client_pos.x;
                clip_pos.width = client_pos.width;
            }
            if (!valid_y)
            {
                clip_pos.y = client_pos.y;
                clip_pos.height = client_pos.height;
            }
            _clips.Add(clip_pos);
        }

        public void del_clip()
        {
            if (_clips.Count != 0)
                _clips.RemoveAt(_clips.Count - 1);
        }

        protected void fill_rect(Graphics hdc, int x, int y, int width, int height, web_color color, css_border_radius radius)
        {
        }

        protected void draw_ellipse(Graphics hdc, int x, int y, int width, int height, web_color color, int line_width)
        {
        }

        protected void fill_ellipse(Graphics hdc, int x, int y, int width, int height, web_color color)
        {
        }

        protected void clear_images()
        {
            _images.Clear();
        }

        public string get_default_font_name() => "sans-serif";

        public element create_element(string tag_name, Dictionary<string, string> attributes, document doc) => null;

        public void get_media_features(media_features media)
        {
            get_client_rect(out var client);
            media.type = media_type.screen;
            media.width = client.width;
            media.height = client.height;
            // var screen = Screen.FromControl(this);
            // var screenBounds = screen.Bounds;
            // media.device_width = screenBounds.Width;
            // media.device_height = screenBounds.Height;
            media.color = 8;
            media.monochrome = 0;
            media.color_index = 256;
            media.resolution = 96;
        }

        public void get_language(out string language, out string culture) { language = "en"; culture = string.Empty; }

        public void link(document doc, element el) { }

        protected static string urljoin(string base_, string relative)
        {
            try { return new Uri(new Uri(base_), relative).ToString(); }
            catch { return relative; }
        }
    }
}
