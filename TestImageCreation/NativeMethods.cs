using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Ink;
using System.Windows.Interop;

namespace TestImageCreation
{
    //public static class NativeMethods
    //{
    //    //public static Image GetFileImage(string path, Size itemSize)
    //    //{
    //    //    var shfi = new SHFILEINFO();
    //    //    var imageList = SHGetFileInfoAsImageList(path, 0, ref shfi, (uint)Marshal.SizeOf(shfi), (int)SHGFI_SYSICONINDEX);
    //    //    if (imageList != null)
    //    //    {
    //    //        var hIcon = IntPtr.Zero;
    //    //        imageList.GetIcon(shfi.iIcon, (int)ILD_TRANSPARENT, ref hIcon);
    //    //        Marshal.FinalReleaseComObject(imageList);
    //    //        if (hIcon != IntPtr.Zero)
    //    //        {
    //    //            var image = Bitmap.FromHicon(hIcon);
    //    //            DestroyIcon(hIcon);
    //    //            return image;
    //    //        }
    //    //    }
    //    //    return new Bitmap(itemSize.Width, itemSize.Height);
    //    //}

    //    //[DllImport("shell32.dll", EntryPoint = "SHGetFileInfo", CharSet = CharSet.Auto)]
    //    //private static extern ImageList SHGetFileInfoAsImageList(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

    //}

    //public class IconHelper
    //{
    //    // Constants that we need in the function call

    //    private const int SHGFI_ICON = 0x100;

    //    private const int SHGFI_SMALLICON = 0x1;

    //    private const int SHGFI_LARGEICON = 0x0;

    //    private const int SHIL_JUMBO = 0x4;
    //    private const int SHIL_EXTRALARGE = 0x2;

    //    // This structure will contain information about the file

    //    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    //    public struct SHFILEINFO
    //    {

    //        // Handle to the icon representing the file

    //        public IntPtr hIcon;

    //        // Index of the icon within the image list

    //        public int iIcon;

    //        // Various attributes of the file

    //        public uint dwAttributes;

    //        // Path to the file

    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]

    //        public string szDisplayName;

    //        // File type

    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]

    //        public string szTypeName;

    //    };

    //    [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
    //    public static extern Boolean CloseHandle(IntPtr handle);

    //    private struct IMAGELISTDRAWPARAMS
    //    {
    //        public int cbSize;
    //        public IntPtr himl;
    //        public int i;
    //        public IntPtr hdcDst;
    //        public int x;
    //        public int y;
    //        public int cx;
    //        public int cy;
    //        public int xBitmap;        // x offest from the upperleft of bitmap
    //        public int yBitmap;        // y offset from the upperleft of bitmap
    //        public int rgbBk;
    //        public int rgbFg;
    //        public int fStyle;
    //        public int dwRop;
    //        public int fState;
    //        public int Frame;
    //        public int crEffect;
    //    }

    //    [StructLayout(LayoutKind.Sequential)]
    //    private struct IMAGEINFO
    //    {
    //        public IntPtr hbmImage;
    //        public IntPtr hbmMask;
    //        public int Unused1;
    //        public int Unused2;
    //        //public Rect rcImage;
    //    }

    //    //private static IImageList GetSystemImageListHandle(IconSizeType sizeType)
    //    //{
    //    //    IImageList iImageList = null;
    //    //    Guid imageListGuid = new Guid("2C247F21-8591-11D1-B16A-00C0F0283628");
    //    //    int ret = SHGetImageList((int)sizeType, ref imageListGuid, ref iImageList);
    //    //    return iImageList;
    //    //}

    //    [ComImport,
    //   Guid("2C247F21-8591-11D1-B16A-00C0F0283628"),
    //   InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    //    private interface IImageList
    //    {
    //        [PreserveSig]
    //        int Add(IntPtr hbmImage, IntPtr hbmMask, ref int pi);
    //        [PreserveSig]
    //        int ReplaceIcon(int i, IntPtr hicon, ref int pi);
    //        [PreserveSig]
    //        int SetOverlayImage(int iImage, int iOverlay);
    //        [PreserveSig]
    //        int Replace(int i, IntPtr hbmImage, IntPtr hbmMask);
    //        [PreserveSig]
    //        int AddMasked(IntPtr hbmImage, int crMask, ref int pi);
    //        [PreserveSig]
    //        int Draw(ref IMAGELISTDRAWPARAMS pimldp);
    //        [PreserveSig]
    //        int Remove(int i);
    //        [PreserveSig]
    //        int GetIcon(int i, int flags, ref IntPtr picon);
    //        [PreserveSig]
    //        int GetImageInfo(int i, ref IMAGEINFO pImageInfo);
    //        [PreserveSig]
    //        int Copy(int iDst, IImageList punkSrc, int iSrc, int uFlags);
    //        [PreserveSig]
    //        int Merge(int i1, IImageList punk2, int i2, int dx, int dy, ref Guid riid, ref IntPtr ppv);
    //        [PreserveSig]
    //        int Clone(ref Guid riid, ref IntPtr ppv);
    //        [PreserveSig]
    //        int GetImageRect(int i, ref RECT prc);
    //        [PreserveSig]
    //        int GetIconSize(ref int cx, ref int cy);
    //        [PreserveSig]
    //        int SetIconSize(int cx, int cy);
    //        [PreserveSig]
    //        int GetImageCount(ref int pi);
    //        [PreserveSig]
    //        int SetImageCount(int uNewCount);
    //        [PreserveSig]
    //        int SetBkColor(int clrBk, ref int pclr);
    //        [PreserveSig]
    //        int GetBkColor(ref int pclr);
    //        [PreserveSig]
    //        int BeginDrag(int iTrack, int dxHotspot, int dyHotspot);
    //        [PreserveSig]
    //        int EndDrag();
    //        [PreserveSig]
    //        int DragEnter(IntPtr hwndLock, int x, int y);
    //        [PreserveSig]
    //        int DragLeave(IntPtr hwndLock);
    //        [PreserveSig]
    //        int DragMove(int x, int y);
    //        [PreserveSig]
    //        int SetDragCursorImage(ref IImageList punk, int iDrag, int dxHotspot, int dyHotspot);
    //        [PreserveSig]
    //        int DragShowNolock(int fShow);
    //        [PreserveSig]
    //        int GetDragImage(ref POINT ppt, ref POINT pptHotspot, ref Guid riid, ref IntPtr ppv);
    //        [PreserveSig]
    //        int GetItemFlags(int i, ref int dwFlags);
    //        [PreserveSig]
    //        int GetOverlayImage(int iOverlay, ref int piIndex);
    //    }
    //   ;
    //    //private static extern ImageList SHGetFileInfoAsImageList(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

    //    [StructLayout(LayoutKind.Sequential)]
    //    public struct RECT
    //    {
    //        public int Left, Top, Right, Bottom;
    //        public RECT(int l, int t, int r, int b)
    //        {
    //            Left = l;
    //            Top = t;
    //            Right = r;
    //            Bottom = b;
    //        }

    //        public RECT(Rectangle r)
    //        {
    //            Left = r.Left;
    //            Top = r.Top;
    //            Right = r.Right;
    //            Bottom = r.Bottom;
    //        }

    //        public Rectangle ToRectangle()
    //        {
    //            return Rectangle.FromLTRB(Left, Top, Right, Bottom);
    //        }

    //        public void Inflate(int width, int height)
    //        {
    //            Left -= width;
    //            Top -= height;
    //            Right += width;
    //            Bottom += height;
    //        }

    //        public override string ToString()
    //        {
    //            return string.Format("x:{0},y:{1},width:{2},height:{3}", Left, Top, Right - Left, Bottom - Top);
    //        }
    //    }


    //    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    //    public struct POINT
    //    {
    //        public int X, Y;
    //        public POINT(int x, int y)
    //        {
    //            this.X = x;
    //            this.Y = y;
    //        }

    //        public POINT(Point pt)
    //        {
    //            this.X = pt.X;
    //            this.Y = pt.Y;
    //        }

    //        public Point ToPoint()
    //        {
    //            return new Point(X, Y);
    //        }
    //    }

    //    // The signature of SHGetFileInfo (located in Shell32.dll)

    //    [DllImport("shell32.dll", SetLastError = true)]
    //    static extern int SHGetSpecialFolderLocation(IntPtr hwndOwner, Int32 nFolder,
    //             ref IntPtr ppidl);


    //    // The signature of SHGetFileInfo (located in Shell32.dll)
    //    [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
    //    public static extern int SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, uint uFlags);

    //    [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
    //    public static extern int SHGetFileInfo(IntPtr pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, uint uFlags);

    //    //[DllImport("shell32.dll", EntryPoint = "#727")]
    //    //private static extern int SHGetImageList(int iImageList, ref Guid riid, ref IImageList ppv);

    //    [DllImport("user32")]
    //    public static extern int DestroyIcon(IntPtr hIcon);


    //    [DllImport("shell32.dll", EntryPoint = "#727")]
    //    private extern static int SHGetImageList(
    //  int iImageList,
    //  ref Guid riid,
    //  out IImageList ppv
    //  );

    //    public enum IconSizeType
    //    {
    //        Medium = 0x0,
    //        Small = 0x1,
    //        Large = 0x2,
    //        ExtraLarge = 0x4
    //    }
    //    public struct pair
    //    {
    //        public System.Drawing.Icon icon { get; set; }
    //        public IntPtr iconHandleToDestroy { set; get; }

    //    }


    //    //private static byte[] ByteFromIcon(System.Drawing.Icon ic)
    //    //{
    //    //    var icon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(ic.Handle,
    //    //                                            System.Windows.Int32Rect.Empty,
    //    //                                            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
    //    //    icon.Freeze();
    //    //    byte[] data;
    //    //    PngBitmapEncoder encoder = new PngBitmapEncoder();
    //    //    encoder.Frames.Add(BitmapFrame.Create(icon));
    //    //    using (MemoryStream ms = new MemoryStream())
    //    //    {
    //    //        encoder.Save(ms);
    //    //        data = ms.ToArray();
    //    //    }
    //    //    return data;
    //    //}
    //    //private static Icon GetSmallIcon(string FileName, IconSize iconSize)
    //    //{
    //    //    SHFILEINFO shinfo = new SHFILEINFO();
    //    //    uint flags;
    //    //    if (iconSize == IconSize.Small)
    //    //    {
    //    //        flags = SHGFI_ICON | SHGFI_SMALLICON;
    //    //    }
    //    //    else
    //    //    {
    //    //        flags = SHGFI_ICON | SHGFI_LARGEICON;
    //    //    }
    //    //    var res = SHGetFileInfo(FileName, 0, ref shinfo, Marshal.SizeOf(shinfo), flags);
    //    //    if (res == 0)
    //    //    {
    //    //        throw ( new System.IO.FileNotFoundException() );
    //    //    }
    //    //    var ico = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shinfo.hIcon);
    //    //    //var bs = ByteFromIcon(ico);
    //    //    //ico.Dispose();
    //    //    //DestroyIcon(shinfo.hIcon);
    //    //    return ico;
    //    //}

    //    internal static Icon GetLargeIcon(string FileName)
    //    {
    //        SHFILEINFO shinfo = new SHFILEINFO();
    //        uint SHGFI_SYSICONINDEX = 0x4000;
    //        int FILE_ATTRIBUTE_NORMAL = 0x80;
    //        uint flags;
    //        flags = SHGFI_SYSICONINDEX;
    //        var res = SHGetFileInfo(FileName, FILE_ATTRIBUTE_NORMAL, ref shinfo, Marshal.SizeOf(shinfo), flags);
    //        if (res == 0)
    //        {
    //            throw ( new System.IO.FileNotFoundException() );
    //        }
    //        var iconIndex = shinfo.iIcon;
    //        //Guid iidImageList = new Guid("2C247F21-8591-11D1-B16A-00C0F0283628");
    //        //IImageList iml;
    //        int size = SHIL_EXTRALARGE;
    //        //var hres = SHGetImageList(size, ref iidImageList, ref iml); // writes iml

    //        IImageList imageList = (IImageList)GetSystemImageListHandle(IconSizeType.Large);
    //        IntPtr hIcon = IntPtr.Zero;
    //        int ILD_TRANSPARENT = 1;
    //        if (imageList != null)
    //            imageList.GetIcon(iconIndex, ILD_TRANSPARENT, ref hIcon);
    //        Icon ico = null;

    //        if (hIcon != IntPtr.Zero)
    //        {
    //            ico = System.Drawing.Icon.FromHandle(hIcon);
    //            //var bs = ByteFromIcon(ico);
    //            ico.Dispose();
    //            DestroyIcon(hIcon);
    //        }
    //        return ico;
    //    }

    //    private static IImageList GetSystemImageListHandle(IconSizeType sizeType)
    //    {
    //        IImageList iImageList = null;
    //        Guid imageListGuid = new Guid("EB612DE5-20AD-4622-85CB-75BCC3D735E7");
    //        int ret = SHGetImageList((int)sizeType, ref imageListGuid, out iImageList);
    //        var hres = SHGetImageList((int)sizeType, ref imageListGuid, out iImageList);
    //        return iImageList;
    //    }

    //}

    public class Helper
    {
        private const uint ILD_TRANSPARENT = 0x00000001;
        public const uint ILD_IMAGE = 0x00000020;
        private const uint SHGFI_SYSICONINDEX = 0x000005000;
        private const uint SHGFI_ICON = 0x000000100;
        public static readonly int MaxEntitiesCount = 80;
        public static void GetDirectories(string path, List<Image> col, IconSizeType sizeType, Size itemSize)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            DirectoryInfo[] dirs = dirInfo.GetDirectories("*", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < dirs.Length && i < MaxEntitiesCount; i++)
            {
                DirectoryInfo subDirInfo = dirs[i];
                if (!CheckAccess(subDirInfo) || !MatchFilter(subDirInfo.Attributes))
                {
                    continue;
                }
                col.Add(GetFileImage(subDirInfo.FullName, sizeType, itemSize));
            }
        }

        public static bool CheckAccess(DirectoryInfo info)
        {
            bool isOk = false;
            try
            {
                var secInfo = info.GetAccessControl();
                isOk = true;
            }
            catch
            {
            }
            return isOk;
        }

        public static bool MatchFilter(FileAttributes attributes)
        {
            return ( attributes & ( FileAttributes.Hidden | FileAttributes.System ) ) == 0;
        }

        [DllImport("shell32.dll", EntryPoint = "SHGetFileInfo", CharSet = CharSet.Auto)]
        private static extern IImageList SHGetFileInfoAsImageList(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        public static Image GetFileImageFromFile(string path, IconSizeType sizeType, Size itemSize)
        {
            var shfi = new SHFILEINFO();
            var imageList = SHGetFileInfoAsImageList(path, 0, ref shfi, (uint)Marshal.SizeOf(shfi), (int)SHGFI_SYSICONINDEX);
            if (imageList != null)
            {
                var hIcon = IntPtr.Zero;
                imageList.GetIcon(shfi.iIcon, (int)ILD_TRANSPARENT, ref hIcon);
                Marshal.FinalReleaseComObject(imageList);
                if (hIcon != IntPtr.Zero)
                {
                    var image = Bitmap.FromHicon(hIcon);
                    DestroyIcon(hIcon);
                    return image;
                }
            }
            return new Bitmap(itemSize.Width, itemSize.Height);
        }

        public static Image GetFileImage(string path, IconSizeType sizeType, Size itemSize)
        {
            return IconToBitmap(GetFileIcon(path, sizeType, itemSize), sizeType, itemSize);
        }

        public static Image IconToBitmap(Icon ico, IconSizeType sizeType, Size itemSize)
        {
            if (ico == null)
            {
                return new Bitmap(itemSize.Width, itemSize.Height);
            }
            return ico.ToBitmap();
        }

        public static Icon GetFileIcon(string path, IconSizeType sizeType, Size itemSize)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            IntPtr retVal = SHGetFileInfo(path, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), (int)( SHGFI_SYSICONINDEX | SHGFI_ICON ));
            int iconIndex = shinfo.iIcon;
            IImageList iImageList = (IImageList)GetSystemImageListHandle(sizeType);
            IntPtr hIcon = IntPtr.Zero;
            if (iImageList != null)
            {
                iImageList.GetIcon(iconIndex, (int)ILD_TRANSPARENT, ref hIcon);
                Marshal.FinalReleaseComObject(iImageList);
            }
            Icon icon = null;
            if (hIcon != IntPtr.Zero)
            {
                icon = Icon.FromHandle(hIcon).Clone() as Icon;
                DestroyIcon(shinfo.hIcon);
            }
            return icon;
        }

        private static IImageList GetSystemImageListHandle(IconSizeType sizeType)
        {
            IImageList iImageList = null;
            Guid imageListGuid = new Guid("46EB5926-582E-4017-9FDF-E8998DAA0950");
            int ret = SHGetImageList((int)sizeType, ref imageListGuid, ref iImageList);
            return iImageList;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
        [DllImport("shell32.dll", EntryPoint = "#727")]
        private static extern int SHGetImageList(int iImageList, ref Guid riid, ref IImageList ppv);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);
        public enum IconSizeType
        {
            Medium = 0x0,
            Small = 0x1,
            Large = 0x2,
            ExtraLarge = 0x4
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [ComImport,
        Guid("46EB5926-582E-4017-9FDF-E8998DAA0950"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IImageList
        {
            [PreserveSig]
            int Add(IntPtr hbmImage, IntPtr hbmMask, ref int pi);
            [PreserveSig]
            int ReplaceIcon(int i, IntPtr hicon, ref int pi);
            [PreserveSig]
            int SetOverlayImage(int iImage, int iOverlay);
            [PreserveSig]
            int Replace(int i, IntPtr hbmImage, IntPtr hbmMask);
            [PreserveSig]
            int AddMasked(IntPtr hbmImage, int crMask, ref int pi);
            [PreserveSig]
            int Draw(ref IMAGELISTDRAWPARAMS pimldp);
            [PreserveSig]
            int Remove(int i);
            [PreserveSig]
            int GetIcon(int i, int flags, ref IntPtr picon);
            [PreserveSig]
            int GetImageInfo(int i, ref IMAGEINFO pImageInfo);
            [PreserveSig]
            int Copy(int iDst, IImageList punkSrc, int iSrc, int uFlags);
            [PreserveSig]
            int Merge(int i1, IImageList punk2, int i2, int dx, int dy, ref Guid riid, ref IntPtr ppv);
            [PreserveSig]
            int Clone(ref Guid riid, ref IntPtr ppv);
            [PreserveSig]
            int GetImageRect(int i, ref RECT prc);
            [PreserveSig]
            int GetIconSize(ref int cx, ref int cy);
            [PreserveSig]
            int SetIconSize(int cx, int cy);
            [PreserveSig]
            int GetImageCount(ref int pi);
            [PreserveSig]
            int SetImageCount(int uNewCount);
            [PreserveSig]
            int SetBkColor(int clrBk, ref int pclr);
            [PreserveSig]
            int GetBkColor(ref int pclr);
            [PreserveSig]
            int BeginDrag(int iTrack, int dxHotspot, int dyHotspot);
            [PreserveSig]
            int EndDrag();
            [PreserveSig]
            int DragEnter(IntPtr hwndLock, int x, int y);
            [PreserveSig]
            int DragLeave(IntPtr hwndLock);
            [PreserveSig]
            int DragMove(int x, int y);
            [PreserveSig]
            int SetDragCursorImage(ref IImageList punk, int iDrag, int dxHotspot, int dyHotspot);
            [PreserveSig]
            int DragShowNolock(int fShow);
            [PreserveSig]
            int GetDragImage(ref POINT ppt, ref POINT pptHotspot, ref Guid riid, ref IntPtr ppv);
            [PreserveSig]
            int GetItemFlags(int i, ref int dwFlags);
            [PreserveSig]
            int GetOverlayImage(int iOverlay, ref int piIndex);
        }
        ;

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGELISTDRAWPARAMS
        {
            public int cbSize;
            public IntPtr himl;
            public int i;
            public IntPtr hdcDst;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int xBitmap;
            public int yBitmap;
            public int rgbBk;
            public int rgbFg;
            public int fStyle;
            public int dwRop;
            public int fState;
            public int Frame;
            public int crEffect;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGEINFO
        {
            public IntPtr hbmImage;
            public IntPtr hbmMask;
            public int Unused1;
            public int Unused2;
            public RECT rcImage;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;
            public RECT(int l, int t, int r, int b)
            {
                Left = l;
                Top = t;
                Right = r;
                Bottom = b;
            }

            public RECT(Rectangle r)
            {
                Left = r.Left;
                Top = r.Top;
                Right = r.Right;
                Bottom = r.Bottom;
            }

            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(Left, Top, Right, Bottom);
            }

            public void Inflate(int width, int height)
            {
                Left -= width;
                Top -= height;
                Right += width;
                Bottom += height;
            }

            public override string ToString()
            {
                return string.Format("x:{0},y:{1},width:{2},height:{3}", Left, Top, Right - Left, Bottom - Top);
            }
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct POINT
        {
            public int X, Y;
            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public POINT(Point pt)
            {
                this.X = pt.X;
                this.Y = pt.Y;
            }

            public Point ToPoint()
            {
                return new Point(X, Y);
            }
        }
    }
}
