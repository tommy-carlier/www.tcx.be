// old method that locks the file:
Image img = Image.FromFile("picture.jpg");

// new method that does not lock the file:
Image img = Utils.ImageFromFile("picture.jpg");