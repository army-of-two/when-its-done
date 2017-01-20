﻿namespace WhenItsDone.Models.Constants
{
    public static class ValidationConstants
    {
        public const int CountryMinLength = 2;
        public const int CountryMaxLength = 50;

        public const int CityMinLength = 2;
        public const int CityMaxLength = 50;

        public const int StreetMinLength = 2;
        public const int StreetMaxLength = 100;

        public const int NameMinLength = 2;
        public const int NameMaxLength = 50;

        public const int AgeMinValue = 18;
        public const int AgeMaxValue = 150;

        public const int ReviewContentMinLength = 2;
        public const int ReviewContentMaxLength = 250;

        public const int RatingMinValue = -100;
        public const int RatingMaxValue = 100;

        public const int ScoreMinValue = 0;
        public const int ScoreMaxValue = int.MaxValue;

        public const int EmailMinLength = 5;
        public const int EmailMaxLength = 100;

        public const int PhoneMinLength = 4;
        public const int PhoneMaxLength = 15;
    }
}
