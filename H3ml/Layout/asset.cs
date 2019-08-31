using System.Collections.Generic;

namespace H3ml.Layout
{
    public class asset_paint
    {
        public string asset;
        public Dictionary<string, string> attributes;
        public string baseurl;
        public web_color color;
        public position clip_box;
        public position origin_box;
        public position border_box;
        public size asset_size;
        public int position_x;
        public int position_y;
        public int position_z; //:h3ml
        public bool is_root;

        public asset_paint()
        {
            color = new web_color(0, 0, 0, 0);
            position_x = 0;
            position_y = 0;
            position_z = 0; //:h3ml
            is_root = false;
        }
        public asset_paint(asset_paint val)
        {
            asset = val.asset;
            attributes = val.attributes;
            baseurl = val.baseurl;
            color = val.color;
            clip_box = val.clip_box;
            origin_box = val.origin_box;
            border_box = val.border_box;
            asset_size = val.asset_size;
            position_x = val.position_x;
            position_y = val.position_y;
            position_z = val.position_z; //:h3ml
            is_root = val.is_root;
        }
    }
}