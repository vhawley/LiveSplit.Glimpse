﻿using LiveSplit.Model;
using LiveSplit.Options;
using LiveSplit.TimeFormatters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public class GlimpseComponent : IComponent
    {
        public Settings Settings { get; set; }

        protected LiveSplitState State { get; set; }
        protected Form Form { get; set; }

        public float PaddingTop => 0;
        public float PaddingBottom => 0;
        public float PaddingLeft => 0;
        public float PaddingRight => 0;

        public string ComponentName => $"Glimpse";

        public IDictionary<string, Action> ContextMenuControls { get; protected set; }

        public GlimpseComponent(LiveSplitState state)
        {
            Settings = new Settings();

            ContextMenuControls = new Dictionary<string, Action>();
            ContextMenuControls.Add("Glimpse Settings", OpenGlimpseSettings);

            State = state;
            Form = state.Form;
            
            // add event listeners
            State.OnStart += State_OnStart;
            State.OnSplit += State_OnSplit;
            State.OnReset += State_OnReset;
            State.OnSkipSplit += State_OnSkipSplit;
            State.OnUndoSplit += State_OnUndoSplit;
            State.OnPause += State_OnPause;
            State.OnResume += State_OnResume;

            // Events not supported currently 
            State.OnUndoAllPauses += State_OnUndoAllPauses;
            State.OnSwitchComparisonPrevious += State_OnSwitchComparisonPrevious;
            State.OnSwitchComparisonNext += State_OnSwitchComparisonNext;
            
        }
        
        public void OpenGlimpseSettings()
        {
            Console.Out.WriteLine("OpenGlimpseSettings");
        }

        private void State_OnStart(object sender, EventArgs e)
        {
            Console.Out.WriteLine("OnStart");
        }

        private void State_OnSplit(object sender, EventArgs e)
        {
            Console.Out.WriteLine("OnSplit");
        }

        private void State_OnReset(object sender, TimerPhase e)
        {
            Console.Out.WriteLine("OnReset");
        }

        private void State_OnSkipSplit(object sender, EventArgs e)
        {
            Console.Out.WriteLine("OnSkipSplit");
        }

        private void State_OnUndoSplit(object sender, EventArgs e)
        {
            Console.Out.WriteLine("OnUndoSplit");
        }

        private void State_OnPause(object sender, EventArgs e)
        {
            Console.Out.WriteLine("OnPause");
        }

        private void State_OnResume(object sender, EventArgs e)
        {
            Console.Out.WriteLine("OnResume");
        }

        private void State_OnUndoAllPauses(object sender, EventArgs e)
        {
            Console.Out.WriteLine("OnUndoAllPauses");
        }

        private void State_OnSwitchComparisonPrevious(object sender, EventArgs e)
        {
            Console.Out.WriteLine("OnSwitchComparisonPrevious");
        }

        private void State_OnSwitchComparisonNext(object sender, EventArgs e)
        {
            Console.Out.WriteLine("OnSwitchComparisonNext");
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
        }

        public float VerticalHeight => 0;

        public float MinimumWidth => 0;

        public float HorizontalWidth => 0;

        public float MinimumHeight => 0;

        public XmlNode GetSettings(XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            return Settings;
        }

        public void SetSettings(XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
        }

        public void Dispose()
        {
            // remove event listeners
            State.OnStart -= State_OnStart;
        }

        public int GetSettingsHashCode()
        {
            return Settings.GetSettingsHashCode();
        }
    }
}