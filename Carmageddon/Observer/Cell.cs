namespace Carmageddon.Forms.Observer
{
    // OBSERVER / SUBSCRIBER
    internal class Cell
    {
        private Form2 Form2 { get; set; }
        private string Coordinates { get; set; }
        private int PictureAxisX { get; set; }
        private int PictureAxisY { get; set; }
        private bool IsHit { get; set; }

        public Cell(Form2 form2, string coordinates, int pictureAxisX, int pictureAxisY)
        {
            Form2 = form2;
            Coordinates = coordinates;
            IsHit = false;
            PictureAxisX = pictureAxisX;
            PictureAxisY = pictureAxisY;
        }

        public void CheckIfHit(string coords)
        {
            if(coords == Coordinates && !IsHit)
            {
                IsHit = true;
                Form2.AddShot(PictureAxisX, PictureAxisY);
            }
        }

    }
}
