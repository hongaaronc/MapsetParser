﻿using MapsetParser.objects;
using MapsetParser.objects.hitobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MapsetParser.statics
{
    internal static class SkinStatic
    {
        private static bool isInitialized = false;
        
        private static readonly string[] skinGeneral = new string[]
        {
            // cursor
            "cursor.png",
            "cursormiddle.png",
            "cursor-smoke.png",
            "cursortrail.png",
            // playfield
            "play-skip-{n}.png",
            "play-unranked.png",
            "multi-skipped.png",
            // pause screen
            "pause-overlay.png",    "pause-overlay.jpg",    // according to the wiki page these are the only two which have jpg alternatives
            "fail-background.png",  "fail-background.jpg",
            "pause-back.png",
            "pause-continue.png",
            "pause-replay.png",
            "pause-retry.png",
            // scorebar
            "scorebar-bg.png",
            "scorebar-colour.png",
            // score numbers
            "score-0.png",
            "score-1.png",
            "score-2.png",
            "score-3.png",
            "score-4.png",
            "score-5.png",
            "score-6.png",
            "score-7.png",
            "score-8.png",
            "score-9.png",
            "score-comma.png",
            "score-dot.png",
            "score-percent.png",
            "score-x.png",
            // ranking grades
            "ranking-XH-small.png",
            "ranking-X-small.png",
            "ranking-SH-small.png",
            "ranking-S-small.png",
            "ranking-A-small.png",
            "ranking-B-small.png",
            "ranking-C-small.png",
            "ranking-D-small.png",
            // score entry (used in the leaderboard while in gameplay)
            "scoreentry-0.png",
            "scoreentry-1.png",
            "scoreentry-2.png",
            "scoreentry-3.png",
            "scoreentry-4.png",
            "scoreentry-5.png",
            "scoreentry-6.png",
            "scoreentry-7.png",
            "scoreentry-8.png",
            "scoreentry-9.png",
            "scoreentry-comma.png",
            "scoreentry-dot.png",
            "scoreentry-percent.png",
            "scoreentry-x.png",
            // song selection (used in the in-game leaderboard, among other stuff like kiai)
            "menu-button-background.png",
            "selection-tab.png",
            "star2.png",
            // mod icons (appears in the top right of the screen in gameplay)
            "selection-mod-autoplay.png",
            "selection-mod-cinema.png",
            "selection-mod-doubletime.png",
            "selection-mod-easy.png",
            "selection-mod-flashlight.png",
            "selection-mod-halftime.png",
            "selection-mod-hardrock.png",
            "selection-mod-hidden.png",
            "selection-mod-nightcore.png",
            "selection-mod-nofail.png",
            "selection-mod-perfect.png",
            "selection-mod-suddendeath.png",
            // sounds in gameplay
            "applause.wav", "applause.mp3", "applause.ogg",
            "comboburst.wav", "comboburst.mp3", "comboburst.ogg",
            "combobreak.wav", "combobreak.mp3", "combobreak.ogg",
            "failsound.wav", "failsound.mp3", "failsound.ogg",
            // sounds in the pause screen
            "pause-loop.wav", "pause-loop.mp3", "pause-loop.ogg"
        };

        private static readonly string[] skinStandard = new string[]
        {
            // hit bursts
            "hit0-{n}.png",
            "hit50-{n}.png",
            "hit100-{n}.png",
            "hit100k-{n}.png",
            "hit300-{n}.png",
            "hit300g-{n}.png",
            "hit300k-{n}.png",
            // mod icons exceptions
            "selection-mod-relax2.png",
            "selection-mod-spunout.png",
            "selection-mod-target.png", // currently only cutting edge
            // combo burst
            "comboburst.png",
            "comboburst-{n}.png",
            // default numbers, used for combos
            "default-0.png",
            "default-1.png",
            "default-2.png",
            "default-3.png",
            "default-4.png",
            "default-5.png",
            "default-6.png",
            "default-7.png",
            "default-8.png",
            "default-9.png",
            // hit circles
            "approachcircle.png",
            "hitcircle.png",
            "hitcircleoverlay.png",
            "hitcircleoverlay-{n}.png",
            "hitcircleselect.png",
            "followpoint.png",
            "followpoint-{n}.png",
            "lighting.png"
        };

        private static readonly string[] skinMania = new string[]
        {
            // mod icons
            "selection-mod-fadein.png",
            "selection-mod-key1.png",
            "selection-mod-key2.png",
            "selection-mod-key3.png",
            "selection-mod-key4.png",
            "selection-mod-key5.png",
            "selection-mod-key6.png",
            "selection-mod-key7.png",
            "selection-mod-key8.png",
            "selection-mod-key9.png",
            "selection-mod-keycoop.png",
            "selection-mod-random.png"
        };

        private static readonly string[] skinCatch = new string[]
        {
            // hit burst exception, appears in both modes' result screens
            // it does but the beatmap-specific skins don't have an effect there
            // "hit0.png",
            // input overlay
            "inputoverlay-background.png",
            "inputoverlay-key.png"
        };

        private static readonly string[] skinNotMania = new string[]
        {
            // scorebar exception, bar is in a different position and excludes this element because of that
            // marker is currently unused (contradicting the wiki), but it's part of the scorebar skin set and may be used in the future
            "scorebar-marker.png",
            // these were meant to be overriden by the marker, but the marker currently does nothing and can even be excluded
            "scorebar-ki.png",
            "scorebar-kidanger.png",
            "scorebar-kidanger2.png",
            // mod icons exception, in mania there's no difference between something clicking for you and just using auto
            "selection-mod-relax.png"
        };

        private static readonly string[] skinCountdown = new string[]
        {
            // playfield
            "count1.png",
            "count2.png",
            "count3.png",
            "go.png",
            "ready.png",
            // sounds
            "count1s.wav", "count1s.mp3", "count1s.ogg",
            "count2s.wav", "count2s.mp3", "count2s.ogg",
            "count3s.wav", "count3s.mp3", "count3s.ogg",
            "gos.wav", "gos.mp3", "gos.ogg",
            "readys.wav", "readys.mp3", "readys.ogg"
        };

        private static readonly string[] skinStandardSlider = new string[]
        {
            // slider
            "sliderstartcircle.png",
            "sliderstartcircleoverlay.png",
            "sliderstartcircleoverlay-{n}.png",
            "sliderendcircle.png",
            "sliderendcircleoverlay.png",
            "sliderendcircleoverlay-{n}.png",
            "sliderfollowcircle.png",
            "sliderfollowcircle-{n}.png",
            "sliderb.png",
            "sliderb{n}.png",
            "sliderb-nd.png",
            "sliderb-spec.png",
            "sliderscorepoint.png",
            "sliderpoint10.png",
            "sliderpoint30.png"
        };

        private static readonly string[] skinStandardSpinner = new string[]
        {
            // spinner
            "spinner-approachcircle.png",
            "spinner-rpm.png",
            "spinner-clear.png",
            "spinner-spin.png",
            "spinner-glow.png",
            "spinner-bottom.png",
            "spinner-top.png",
            "spinner-middle2.png",
            "spinner-middle.png",
            // "old spinner" but apparently it's used still without needing to be in skin v1
            "spinner-background.png",
            "spinner-circle.png",
            "spinner-metre.png",
            "spinner-osu.png",
            // sounds
            "spinnerspin.wav", "spinnerspin.mp3", "spinnerspin.ogg",
            "spinnerbonus.wav", "spinnerbonus.mp3", "spinnerbonus.ogg"
        };

        private static readonly string[] skinNotSliderb = new string[]
        {
            "sliderb-nd.png",
            "sliderb-spec.png"
        };

        private static readonly string[] skinBreak = new string[]
        {
            "section-fail.png",
            "section-pass.png",
            // sounds
            "sectionpass.wav", "sectionpass.mp3", "sectionpass.ogg",
            "sectionfail.wav", "sectionfail.mp3", "sectionfail.ogg"
        };

        // here we do skin elements that aren't necessarily used but can be, given a specific condition
        private struct SkinCondition
        {
            public readonly string[] elementNames;
            public readonly Func<BeatmapSet, bool> isUsed;

            public SkinCondition(string[] elementNames, Func<BeatmapSet, bool> isUsed)
            {
                this.elementNames = elementNames;
                this.isUsed = isUsed;
            }
        }

        private static List<SkinCondition> skinConditions = new List<SkinCondition>();

        private static void AddElements(string[] elements, Func<BeatmapSet, bool> useCondition = null) =>
            skinConditions.Add(new SkinCondition(elements, useCondition));

        private static void AddElement(string element, Func<BeatmapSet, bool> useCondition = null) =>
            skinConditions.Add(new SkinCondition(new string[] { element }, useCondition));

        private static void Initialize()
        {
            // modes, doing or-gates on standard for everything because conversions
            AddElements(skinGeneral);
            AddElements(skinStandard, beatmapSet => beatmapSet.beatmaps.Any(
                beatmap => beatmap.generalSettings.mode == Beatmap.Mode.Standard));
            AddElements(skinCatch, beatmapSet => beatmapSet.beatmaps.Any(
                beatmap =>
                    beatmap.generalSettings.mode == Beatmap.Mode.Catch ||
                    beatmap.generalSettings.mode == Beatmap.Mode.Standard));
            AddElements(skinMania, beatmapSet => beatmapSet.beatmaps.Any(
                beatmap =>
                    beatmap.generalSettings.mode == Beatmap.Mode.Mania ||
                    beatmap.generalSettings.mode == Beatmap.Mode.Standard));
            AddElements(skinNotMania, beatmapSet => beatmapSet.beatmaps.Any(
                beatmap => beatmap.generalSettings.mode != Beatmap.Mode.Mania));

            // TODO: Taiko skin conversion, see issue #6
            /*AddElements(mSkinTaiko, beatmapSet => beatmapSet.mBeatmaps.Any(
                beatmap => beatmap.mGeneralSettings.mMode == Beatmap.Mode.Taiko
                         || beatmap.mGeneralSettings.mMode == Beatmap.Mode.Standard));*/

            // only used in specific cases
            AddElements(skinCountdown, beatmapSet => beatmapSet.beatmaps.Any(
                beatmap => beatmap.generalSettings.countdown > 0));
            AddElements(skinStandardSlider, beatmapSet => beatmapSet.beatmaps.Any(
                beatmap => beatmap.hitObjects.Any(hitObject => hitObject is Slider)));
            AddElement("reversearrow.png", beatmapSet => beatmapSet.beatmaps.Any(
                beatmap => beatmap.hitObjects.Any(hitObject => (hitObject as Slider)?.edgeAmount > 1)));
            AddElements(skinStandardSpinner, beatmapSet => beatmapSet.beatmaps.Any(
                beatmap => beatmap.hitObjects.Any(hitObject => hitObject is Spinner)));
            AddElements(skinBreak, beatmapSet => beatmapSet.beatmaps.Any(
                beatmap => beatmap.breaks.Any()));

            // depending on other skin elements
            AddElements(skinNotSliderb, beatmapSet => !beatmapSet.songFilePaths.Any(
                path => PathStatic.CutPath(path) == "sliderb.png"));
            AddElement("particle50.png", beatmapSet => beatmapSet.songFilePaths.Any(
                path => PathStatic.CutPath(path) == "hit50.png"));
            AddElement("particle100.png", beatmapSet => beatmapSet.songFilePaths.Any(
                path => PathStatic.CutPath(path) == "hit100.png"));
            AddElement("particle300.png", beatmapSet => beatmapSet.songFilePaths.Any(
                path => PathStatic.CutPath(path) == "hit300.png"));

            // animatable elements (animation takes priority over still frame)
            foreach (SkinCondition skinCondition in skinConditions.ToList())
                foreach (string elementName in skinCondition.elementNames)
                    if (elementName.Contains("-{n}"))
                        AddStillFrame(elementName.Replace("-{n}", ""));

            isInitialized = true;
        }

        private static void AddStillFrame(string stillFrame)
        {
            string animatedVersion = stillFrame.Insert(stillFrame.IndexOf("."), "-{n}");
            if (skinConditions.Any(condition => condition.elementNames.Contains(animatedVersion)))
                AddElement(stillFrame, beatmapSet => !beatmapSet.songFilePaths.Any(
                    path => IsAnimationFrameOf(PathStatic.CutPath(path), animatedVersion)));
        }

        private static bool IsAnimationFrameOf(string elementName, string animationName)
        {
            // anAnimationName "abc-{n}.png"
            // anElementName   "abc-71.png"

            int startIndex = animationName.IndexOf("{n}");
            if (startIndex != -1 && elementName.Length > startIndex)
            {
                // Capture from where {n} is until no digits are left.
                string animationFrame = Regex.Match(elementName.Substring(startIndex), @"^\d+").Value;

                if (animationName.Replace("{n}", animationFrame).ToLower() == elementName)
                    return true;
            }

            return false;
        }

        private static SkinCondition? GetSkinCondition(string elementName)
        {
            foreach (SkinCondition skinCondition in skinConditions.ToList())
            {
                foreach (string otherElementName in skinCondition.elementNames)
                {
                    if (otherElementName.ToLower() == elementName.ToLower())
                        return skinCondition;

                    // Animation frames (i.e. "followpoint-{n}.png").
                    if (otherElementName.Contains("{n}"))
                    {
                        int startIndex = otherElementName.IndexOf("{n}");
                        if (startIndex != -1 &&
                            elementName.Length > startIndex &&
                            elementName.IndexOf('.', startIndex) != -1)
                        {
                            int endIndex = elementName.IndexOf('.', startIndex);
                            string frame = elementName.Substring(startIndex, endIndex - startIndex);

                            if (otherElementName.Replace("{n}", frame).ToLower() == elementName)
                                return skinCondition;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary> Returns whether the given skin name is used in the given beatmapset (including animations). </summary>
        public static bool IsUsed(string elementName, BeatmapSet beatmapSet)
        {
            if (!isInitialized)
                Initialize();

            // Find the respective condition for the skin element to be used.
            SkinCondition? skinCondition = GetSkinCondition(elementName);

            // If the condition is null, the skin element is unrecognized and as such not used.
            return
                skinCondition is SkinCondition condition &&
                (condition.isUsed == null || condition.isUsed(beatmapSet));
        }
    }
}
