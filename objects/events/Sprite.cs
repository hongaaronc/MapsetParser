﻿using MapsetParser.statics;
using System.Globalization;
using System.Numerics;

namespace MapsetParser.objects.events
{
    public class Sprite
    {
        // Sprite,Foreground,Centre,"SB\whitenamebar.png",320,240
        // Sprite, layer, origin, filename, x offset, y offset

        public enum Layer
        {
            Background,
            Fail,
            Pass,
            Foreground,
            Overlay,
            Unknown
        }

        public enum Origin
        {
            TopLeft,
            Centre,
            CentreLeft,
            TopRight,
            BottomCentre,
            TopCentre,
            Custom,
            CentreRight,
            BottomLeft,
            BottomRight,
            Unknown
        }

        public readonly Layer   layer;
        public readonly Origin  origin;
        public readonly string  path;
        public readonly Vector2 offset;

        /// <summary> The path in lowercase without extension or quotationmarks. </summary>
        public readonly string strippedPath;

        public Sprite(string[] args)
        {
            layer  = GetLayer(args);
            origin = GetOrigin(args);
            path   = GetPath(args);
            offset = GetOffset(args);

            strippedPath = PathStatic.ParsePath(path, true);
        }

        // layer
        private Layer GetLayer(string[] anArgs) =>
            ParserStatic.GetStoryboardLayer(anArgs);

        // origin
        private Origin GetOrigin(string[] anArgs) =>
            ParserStatic.GetStoryboardOrigin(anArgs);

        /// <summary> Returns the file path which this sprite uses. Retains case sensitivity and extension. </summary>
        private string GetPath(string[] args) =>
            PathStatic.ParsePath(args[3], retainCase: true);

        /// <summary> Returns the positional offset from the top left corner of the screen, if specified,
        /// otherwise default (320, 240). </summary>
        private Vector2 GetOffset(string[] args)
        {
            if (args.Length > 4)
                return new Vector2(
                    float.Parse(args[4], CultureInfo.InvariantCulture),
                    float.Parse(args[5], CultureInfo.InvariantCulture));
            else
                // default coordinates
                return new Vector2(320, 240);
        }
    }
}
