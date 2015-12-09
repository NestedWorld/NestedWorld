using NestedWorld.Classes.ElementsGame.Battle;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NestedWorld.View.BattleViews
{
    public sealed partial class BattleCanvas : UserControl
    {
        private BattleCore _core;

        public BattleCore core
        {
            get { return _core; }
            set
            {
                _core = value;
                value.canvas = mainCanvas;
            }
        }
        public BattleCanvas()
        {
            this.InitializeComponent();
            InkDrawingAttributes inkDrawingAttributes = new InkDrawingAttributes();
            inkDrawingAttributes.Color = Utils.ColorUtils.GetColorFromHex("#FF616668");
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);
            inkCanvas.InkPresenter.StrokeInput.StrokeStarted += StrokeInput_StrokeStarted;
            inkCanvas.InkPresenter.StrokeInput.StrokeEnded += StrokeInput_StrokeEnded;
            Window.Current.SizeChanged += Current_SizeChanged;
            inkCanvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Pen;
        }

        private void StrokeInput_StrokeCanceled(InkStrokeInput sender, Windows.UI.Core.PointerEventArgs args)
        {
            inkCanvas.InkPresenter.StrokeContainer.Clear();
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            inkCanvas.InkPresenter.StrokeContainer.Clear();
        }

        private void StrokeInput_StrokeEnded(InkStrokeInput sender, Windows.UI.Core.PointerEventArgs args)
        {
          
        }

        private void StrokeInput_StrokeStarted(InkStrokeInput sender, Windows.UI.Core.PointerEventArgs args)
        {
            IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
            foreach (InkStroke inkStroke in currentStrokes)
            {
                _core.InkPath(inkStroke.GetInkPoints());
            }
            inkCanvas.InkPresenter.StrokeContainer.Clear();
        }
    }
}
