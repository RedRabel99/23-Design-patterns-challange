using System;
using System.Collections.Generic;

namespace Proxy
{
    public interface IPhotoGallery
    {
        public void SaveImage(Image image);
        public void ShowImages();
        public void DeleteImage(Image image);
    }

    public class Image
    {
        private string _name;
        private int _height;
        private int _width;

        public Image(string name, int height, int width)
        {
            _name = name;
            _height = height;
            _width = width;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetHeight()
        {
            return _height;
        }

        public int GetWidth()
        {
            return _width;
        }
    }

    public class PhotoGallery : IPhotoGallery
    {
        private List<Image> _images;

        public PhotoGallery()
        {
            _images = new List<Image>();
        }

        public void SaveImage(Image image)
        {
            _images.Add(image);
        }

        public void DeleteImage(Image image)
        {
            _images.Remove(image);
        }

        public void ShowImages()
        {
            Console.WriteLine("Images:");
            foreach (var image in _images)
            {
                Console.WriteLine($"name: {image.GetName()} {image.GetWidth()}x{image.GetHeight()}");
            }
        }

        public List<Image> GetImages()
        {
            return _images;
        }
    }

    public class PhotoGalleryProxy : IPhotoGallery
    {
        private PhotoGallery _gallery;
        
        public void SaveImage(Image image)
        {
            if (_gallery == null)
            {
                _gallery = new PhotoGallery();
            }
            
            _gallery.GetImages().Add(image);
        }

        public void DeleteImage(Image image)
        {
            if (_gallery == null)
            {
                _gallery = new PhotoGallery();
            }
            
            _gallery.GetImages().Remove(image);
        }

        public void ShowImages()
        {
            if (_gallery == null)
            {
                _gallery = new PhotoGallery();
            }
            
            Console.WriteLine("Icons:");
            foreach (var image in _gallery.GetImages())
            {
                Console.WriteLine($"name: {image.GetName()} 48x48");
            }
        }
    }
    
    class ProxyProgram
    {
        static void Main(string[] args)
        {
            PhotoGalleryProxy proxy = new PhotoGalleryProxy();
            
            proxy.SaveImage(new Image("name", 200, 200));
            proxy.SaveImage(new Image("name2", 500, 200));
            proxy.SaveImage(new Image("name3", 2000, 2000));
            
            proxy.ShowImages();
        }
    }
}