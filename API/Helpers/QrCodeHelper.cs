using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace API.Helpers
{
    public class QrCodeHelper
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="content">二维码内容，可以是url、文本信息</param>
        /// <param name="savePath">保存地址</param>
        public static void Generate(string content, string savePath)
        {
            // 二维码容错率
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(content, out qrCode);

            using (MemoryStream ms = new MemoryStream())
            {
                var renderer = new GraphicsRenderer(new FixedModuleSize(18, QuietZoneModules.Two));
                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);

                System.Drawing.Image bitmap = new System.Drawing.Bitmap(ms);
                bitmap.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
