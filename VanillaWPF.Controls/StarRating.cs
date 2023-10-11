using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace VanillaWPF.Controls
{
    [TemplatePart(Name = ContentWrapper, Type = typeof(Grid))]
    [TemplateVisualState(GroupName = "RatingStates", Name = HappyGreenStateName)]
    [TemplateVisualState(GroupName = "RatingStates", Name = ScaryRedStateName)]
    [TemplateVisualState(GroupName = "RatingStates", Name = NormalStateName)]
    public class StarRating : Control
    {
        public const string ContentWrapper = "PART_Content";

        public const string HappyGreenStateName = "HappyGreen";
        public const string ScaryRedStateName = "ScaryRed";
        public const string NormalStateName = "Normal";

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(int), typeof(StarRating),
                new PropertyMetadata(default(int), OnValueChanged));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ratingControl = (StarRating)d;

            if (e.NewValue is int newValue)
            {
                if (newValue >= 4)
                {
                    VisualStateManager.GoToState(ratingControl, HappyGreenStateName, true);
                }
                else if (newValue <= 2)
                {
                    VisualStateManager.GoToState(ratingControl, ScaryRedStateName, true);
                }
                else
                {
                    VisualStateManager.GoToState(ratingControl, NormalStateName, false);
                }
            }
        }
        public StarRating()
        {
            MouseDoubleClick += StarRating_MouseDoubleClick;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ContentWrapperGrid = (Grid)GetTemplateChild(ContentWrapper);
            Scale = new ScaleTransform(1, 1);
            ContentWrapperGrid.RenderTransform = Scale;
        }
        private Grid ContentWrapperGrid;

        private bool IsBig { get; set; }
        private ScaleTransform Scale { get; set; }
        private void StarRating_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IsBig = !IsBig;
            if (IsBig)
            {
                Scale.ScaleX = 1.2;
                Scale.ScaleY = 1.2;
            }
            else
            {
                Scale.ScaleX = 1;
                Scale.ScaleY = 1;
            }
        }
    }
}
