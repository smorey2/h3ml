namespace H3ml.Layout
{
    public class el_asset : html_tag
    {
        string _src;

        public el_asset(document doc) : base(doc) => _display = style_display.inline_block;

        public override int line_height => height;
        public override bool is_replaced => true;
        public override int render(int x, int y, int z, int max_width, bool second_pass = false)
        {
            var parent_width = max_width;
            calc_outlines(parent_width);
            _pos.move_to(x, y, z); //:h3ml
            var doc = get_document();
            doc.container.get_asset_size(_src, null, _attrs, out var sz);
            _pos.width = sz.width;
            _pos.height = sz.height;
            _pos.depth = sz.depth; //:h3ml
            if (_css_height.is_predefined && _css_width.is_predefined)
            {
                _pos.height = sz.height;
                _pos.width = sz.width;
                _pos.depth = sz.depth; //:h3ml
                // check for max-height
                if (!_css_max_width.is_predefined)
                {
                    var max_width2 = doc.cvt_units(_css_max_width, _font_size, parent_width);
                    if (_pos.width > max_width2)
                        _pos.width = max_width2;
                    _pos.height = sz.width != 0 ? (int)(_pos.width * (float)sz.height / sz.width) : sz.height;
                }

                // check for max-height
                if (!_css_max_height.is_predefined)
                {
                    var max_height = doc.cvt_units(_css_max_height, _font_size);
                    if (_pos.height > max_height)
                        _pos.height = max_height;
                    _pos.width = sz.height != 0 ? (int)(_pos.height * (float)sz.width / sz.height) : sz.width;
                }
            }
            else if (!_css_height.is_predefined && _css_width.is_predefined)
            {
                if (!get_predefined_height(out _pos.height))
                    _pos.height = (int)_css_height.val;
                // check for max-height
                if (!_css_max_height.is_predefined)
                {
                    var max_height = doc.cvt_units(_css_max_height, _font_size);
                    if (_pos.height > max_height)
                        _pos.height = max_height;
                }
                _pos.width = sz.height != 0 ? (int)(_pos.height * (float)sz.width / sz.height) : sz.width;
            }
            else if (_css_height.is_predefined && !_css_width.is_predefined)
            {
                _pos.width = _css_width.calc_percent(parent_width);
                // check for max-width
                if (!_css_max_width.is_predefined)
                {
                    var max_width2 = doc.cvt_units(_css_max_width, _font_size, parent_width);
                    if (_pos.width > max_width2)
                        _pos.width = max_width2;
                }
                _pos.height = sz.width != 0 ? (int)(_pos.width * (float)sz.height / sz.width) : sz.height;
            }
            else
            {
                _pos.width = _css_width.calc_percent(parent_width);
                _pos.height = 0;
                _pos.depth = 0; //:h3ml
                if (!get_predefined_height(out _pos.height))
                    _pos.height = (int)_css_height.val;

                // check for max-height
                if (!_css_max_height.is_predefined)
                {
                    var max_height = doc.cvt_units(_css_max_height, _font_size);
                    if (_pos.height > max_height)
                        _pos.height = max_height;
                }

                // check for max-height
                if (!_css_max_width.is_predefined)
                {
                    var max_width2 = doc.cvt_units(_css_max_width, _font_size, parent_width);
                    if (_pos.width > max_width2)
                        _pos.width = max_width2;
                }
            }
            calc_auto_margins(parent_width);
            _pos.x += content_margins_left;
            _pos.y += content_margins_top;
            _pos.z += content_margins_front; //:h3ml
            return _pos.width + content_margins_left + content_margins_right;
        }

        public override void parse_attributes()
        {
            _src = get_attr("src", string.Empty);
            var attr_height = get_attr("height"); if (attr_height != null) _style.add_property("height", attr_height, null, false);
            var attr_width = get_attr("width"); if (attr_width != null) _style.add_property("width", attr_width, null, false);
            var attr_depth = get_attr("depth"); if (attr_depth != null) _style.add_property("depth", attr_depth, null, false);
        }

        public override void parse_styles(bool is_reparse = false)
        {
            base.parse_styles(is_reparse);
            if (!string.IsNullOrEmpty(_src))
                get_document().container.load_asset(_src, null, _attrs, !_css_height.is_predefined && !_css_width.is_predefined);
        }

        public override void draw(object hdc, int x, int y, int z, position clip)
        {
            var pos = _pos;
            pos.x += x;
            pos.y += y;
            pos.z += z; //:h3ml
            var el_pos = pos;
            el_pos += _padding;
            el_pos += _borders;

            // draw standard background here
            if (el_pos.does_intersect(clip))
            {
                var bg = get_background();
                if (bg != null)
                {
                    var bg_paint = new background_paint();
                    init_background_paint(pos, bg_paint, bg);
                    get_document().container.draw_background(hdc, bg_paint);
                }
            }

            // draw image as background
            if (pos.does_intersect(clip))
                if (pos.width > 0 && pos.height > 0)
                {
                    var asset = new asset_paint();
                    asset.asset = _src;
                    asset.clip_box = pos;
                    asset.origin_box = pos;
                    asset.border_box = pos;
                    asset.border_box += _padding;
                    asset.border_box += _borders;
                    asset.asset_size.width = pos.width;
                    asset.asset_size.height = pos.height;
                    asset.asset_size.depth = pos.depth; //:h3ml
                    asset.position_x = pos.x;
                    asset.position_y = pos.y;
                    asset.position_z = pos.z; //:h3ml
                    get_document().container.draw_asset(hdc, asset);
                }

            // draw borders
            if (el_pos.does_intersect(clip))
            {
                var border_box = pos;
                border_box += _padding;
                border_box += _borders;
                var bdr = new borders(_css_borders);
                bdr.radius = _css_borders.radius.calc_percents(border_box.width, border_box.height, border_box.depth); //:h3ml
                get_document().container.draw_borders(hdc, bdr, border_box, !have_parent);
            }
        }

        public override void get_content_size(out size sz, int max_width) => get_document().container.get_asset_size(_src, null, _attrs, out sz);
    }
}
