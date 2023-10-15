using System;
using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name = "Low Blood Pressure")] Low,
        [Display(Name = "Ideal Blood Pressure")]  Ideal,
        [Display(Name = "Pre-High Blood Pressure")] PreHigh,
        [Display(Name = "High Blood Pressure")]  High
    };

    public class BloodPressure
    {
        public BloodPressure()
        {

        }
        public BloodPressure(int systolic,int diastolic)
        {
            if (systolic < SystolicMin)
                throw new ArgumentOutOfRangeException(nameof(systolic), "Value is too low");

            if (systolic > SystolicMax)
                throw new ArgumentOutOfRangeException(nameof(systolic), "Value is too high");

            if (diastolic < DiastolicMin)
                throw new ArgumentOutOfRangeException(nameof(diastolic), "Value is too low");

            if (diastolic > DiastolicMax)
                throw new ArgumentOutOfRangeException(nameof(diastolic), "Value is too high");

            if (systolic <= diastolic)
                throw new ArgumentOutOfRangeException(nameof(systolic), "Value must be greater than diastolic value");

            Systolic = systolic;
            Diastolic = diastolic;
        }

        private const int SystolicMin = 70;
        private const int SystolicMax = 190;
        private const int DiastolicMin = 40;
        private const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        private bool IsHighBloodPressure()
        {
            return Systolic >= 140 || Diastolic >= 90;
        }
        private bool IsPreHighBloodPressure()
        {
            return (Systolic >= 120 && Systolic < 150 && Diastolic < 80) || 
                   (Systolic < 140 && Diastolic >= 80 && Diastolic < 90);
        }
        private bool IsIdealBloodPressure()
        {
            return (Systolic >= 90 && Systolic < 120 && Diastolic < 60) ||
                   (Systolic < 120 && Diastolic >= 60 && Diastolic < 80);
        }

        private bool IsLowBloodPressure()
        {
            return Systolic >= 70 && Systolic < 90 && Diastolic < 60;
        }

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                if(IsHighBloodPressure())
                    return BPCategory.High;

                if (IsPreHighBloodPressure())
                    return BPCategory.PreHigh;

                if (IsIdealBloodPressure())
                    return BPCategory.Ideal;

                if (IsLowBloodPressure())
                    return BPCategory.Low;

                throw new InvalidOperationException("No valid blood pressure category found");
            }
        }
    }
}
