﻿using NUnit.Framework;

namespace H3ml.Layout
{
    public class MediaQueryTest
    {
        [Test]
        public void MediaQueryCheckTest()
        {
            media_query_expression e;
            media_features k;

            e = new media_query_expression { feature = media_feature.width, val = 100 };
            k = new media_features { width = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { width = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { width = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_width, val = 100 };
            k = new media_features { width = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { width = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { width = 500 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_width, val = 100 };
            k = new media_features { width = 0 }; Assert.IsTrue(e.check(k));
            k = new media_features { width = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { width = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.height, val = 100 };
            k = new media_features { height = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { height = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_height, val = 100 };
            k = new media_features { height = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { height = 500 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_height, val = 100 };
            k = new media_features { height = 0 }; Assert.IsTrue(e.check(k));
            k = new media_features { height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { height = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.depth, val = 100 };
            k = new media_features { depth = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { depth = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { depth = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_depth, val = 100 };
            k = new media_features { depth = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { depth = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { depth = 500 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_depth, val = 100 };
            k = new media_features { depth = 0 }; Assert.IsTrue(e.check(k));
            k = new media_features { depth = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { depth = 500 }; Assert.IsFalse(e.check(k));

            e = new media_query_expression { feature = media_feature.device_width, val = 100 };
            k = new media_features { device_width = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { device_width = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_width = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_device_width, val = 100 };
            k = new media_features { device_width = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { device_width = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_width = 500 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_device_width, val = 100 };
            k = new media_features { device_width = 0 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_width = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_width = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.device_height, val = 100 };
            k = new media_features { device_height = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { device_height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_height = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_device_height, val = 100 };
            k = new media_features { device_height = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { device_height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_height = 500 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_device_height, val = 100 };
            k = new media_features { device_height = 0 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_height = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.device_depth, val = 100 };
            k = new media_features { device_depth = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { device_depth = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_depth = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_device_depth, val = 100 };
            k = new media_features { device_depth = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { device_depth = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_depth = 500 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_device_depth, val = 100 };
            k = new media_features { device_depth = 0 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_depth = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_depth = 500 }; Assert.IsFalse(e.check(k));

            e = new media_query_expression { feature = media_feature.orientation, val = (int)media_orientation.portrait };
            k = new media_features { width = 0, height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { width = 100, height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { width = 500, height = 100 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.orientation, val = (int)media_orientation.landscape };
            k = new media_features { width = 0, height = 100 }; Assert.IsFalse(e.check(k));
            k = new media_features { width = 100, height = 100 }; Assert.IsFalse(e.check(k));
            k = new media_features { width = 500, height = 100 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.aspect_ratio, val = 100, val2 = 100 };
            k = new media_features { width = 0, height = 100 }; Assert.IsFalse(e.check(k));
            k = new media_features { width = 100, height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { width = 500, height = 100 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_aspect_ratio, val = 100, val2 = 100 };
            k = new media_features { width = 0, height = 100 }; Assert.IsFalse(e.check(k));
            k = new media_features { width = 100, height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { width = 500, height = 100 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_aspect_ratio, val = 100, val2 = 100 };
            k = new media_features { width = 0, height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { width = 100, height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { width = 500, height = 100 }; Assert.IsFalse(e.check(k));

            e = new media_query_expression { feature = media_feature.device_aspect_ratio, val = 100, val2 = 100 };
            k = new media_features { device_width = 0, device_height = 100 }; Assert.IsFalse(e.check(k));
            k = new media_features { device_width = 100, device_height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_width = 500, device_height = 100 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_device_aspect_ratio, val = 100, val2 = 100 };
            k = new media_features { device_width = 0, device_height = 100 }; Assert.IsFalse(e.check(k));
            k = new media_features { device_width = 100, device_height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_width = 500, device_height = 100 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_device_aspect_ratio, val = 100, val2 = 100 };
            k = new media_features { device_width = 0, device_height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_width = 100, device_height = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { device_width = 500, device_height = 100 }; Assert.IsFalse(e.check(k));

            e = new media_query_expression { feature = media_feature.color, val = 100 };
            k = new media_features { color = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { color = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { color = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_color, val = 100 };
            k = new media_features { color = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { color = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { color = 500 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_color, val = 100 };
            k = new media_features { color = 0 }; Assert.IsTrue(e.check(k));
            k = new media_features { color = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { color = 500 }; Assert.IsFalse(e.check(k));

            e = new media_query_expression { feature = media_feature.color_index, val = 100 };
            k = new media_features { color_index = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { color_index = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { color_index = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_color_index, val = 100 };
            k = new media_features { color_index = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { color_index = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { color_index = 500 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_color_index, val = 100 };
            k = new media_features { color_index = 0 }; Assert.IsTrue(e.check(k));
            k = new media_features { color_index = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { color_index = 500 }; Assert.IsFalse(e.check(k));

            e = new media_query_expression { feature = media_feature.monochrome, val = 100 };
            k = new media_features { monochrome = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { monochrome = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { monochrome = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_monochrome, val = 100 };
            k = new media_features { monochrome = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { monochrome = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { monochrome = 500 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_monochrome, val = 100 };
            k = new media_features { monochrome = 0 }; Assert.IsTrue(e.check(k));
            k = new media_features { monochrome = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { monochrome = 500 }; Assert.IsFalse(e.check(k));

            e = new media_query_expression { feature = media_feature.resolution, val = 100 };
            k = new media_features { resolution = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { resolution = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { resolution = 500 }; Assert.IsFalse(e.check(k));
            e = new media_query_expression { feature = media_feature.min_resolution, val = 100 };
            k = new media_features { resolution = 0 }; Assert.IsFalse(e.check(k));
            k = new media_features { resolution = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { resolution = 500 }; Assert.IsTrue(e.check(k));
            e = new media_query_expression { feature = media_feature.max_resolution, val = 100 };
            k = new media_features { resolution = 0 }; Assert.IsTrue(e.check(k));
            k = new media_features { resolution = 100 }; Assert.IsTrue(e.check(k));
            k = new media_features { resolution = 500 }; Assert.IsFalse(e.check(k));
        }

        [Test]
        public void MediaQueryParseTest()
        {
            var doc = new document(new container_test(), null, null);
            media_query q;

            q = media_query.create_from_string("", doc);
            q = media_query.create_from_string("not", doc);
            q = media_query.create_from_string("(width)", doc);
            q = media_query.create_from_string("(orientation: portrait)", doc);
            q = media_query.create_from_string("(width: 1 / 2)", doc);
            q = media_query.create_from_string("(width: 300px)", doc);
            q = media_query.create_from_string("print", doc);
            q = media_query.create_from_string("only screen and (max-width: 600px)", doc);
        }
    }
}
