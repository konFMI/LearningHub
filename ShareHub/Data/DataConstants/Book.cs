namespace ShareHub.Data.DataConstants
{
    public static class Book
    {
        public static int TitleMinLength = 10;
        public static int TitleMaxLength = 50;

        public static int LocationMinLength = 30;
        public static int LocationMaxLength = 150;

        public static int DescriptionMinLength = 50;
        public static int DescriptionMaxLength = 500;

        public static decimal PricePerMonthMinValue = 1;
        public static decimal PricePerMonthMaxValue = 2000;
    }
}