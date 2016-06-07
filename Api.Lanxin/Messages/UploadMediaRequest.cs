
using Api.Lanxin.Enums;
using Api.Lanxin.Helpers;
using Api.Lanxin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Api.Lanxin.Messages
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadMediaRequest
    {
        private MediaType _mediaType;
        private Stream _stream;

        /// <summary>
        /// 
        /// </summary>
        public UploadMediaRequest()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUrl">网络文件地址</param>
        public UploadMediaRequest(string fileUrl)
        {
            var response = HttpHelper.HttpGet.GetResult(fileUrl);
            this.Name = fileUrl.Substring(fileUrl.LastIndexOf("/") + 1);
            this.FullName = "c:" + fileUrl.Substring(fileUrl.IndexOf("/"));
            this._stream = response.Stream;
        }
        /// <summary>
        /// 初始化，同时自动设置属性
        /// </summary>
        /// <param name="fileInfo"></param>
        public UploadMediaRequest(FileInfo fileInfo)
        {
            this.Name = fileInfo.Name;
            this.FullName = fileInfo.FullName;
            _stream = fileInfo.OpenRead();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="file_ext">如.jpg,.amr,.mp4</param>
        public UploadMediaRequest(Stream stream, string file_ext = ".jpg")
        {
            this.Name = "xxxxxxx" + file_ext;
            this.FullName = "c:\\xxxxxxx" + file_ext;
            _stream = stream;
            _stream.Position = 0;
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 文件全路径名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 转成WeixinMedia
        /// </summary>
        /// <returns></returns>
        public PostMedia AsPostMedia()
        {
            return new PostMedia
            {
                Name = this.Name,
                FullName = this.FullName,
                ByteData = this.ByteData
            };
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] ByteData
        {
            get
            {
                if (_stream != null)
                {
                    var desStream = new MemoryStream();
                    _stream.Position = 0;
                    _stream.CopyTo(desStream);
                    return desStream.ToArray();
                }
                var fileInfo = new FileInfo(FullName);
                if (fileInfo.Exists)
                {
                    byte[] tempBuffer = new byte[fileInfo.Length];
                    var fileStream = fileInfo.OpenRead();
                    fileStream.Read(tempBuffer, 0, tempBuffer.Length);
                    return tempBuffer;
                }

                return new byte[0];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MediaType GetMediaType()
        {
            _mediaType = MediaType.file;

            if (!string.IsNullOrEmpty(FullName))
            {
                string ext = FullName.Substring(FullName.LastIndexOf("."));
                switch (ext)
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".gif":
                    case ".bmp":
                        _mediaType = MediaType.image;
                        break;
                    case ".mp4":
                        _mediaType = MediaType.video;
                        break;
                    case ".amr":
                        _mediaType = MediaType.voice;
                        break;
                    default:
                        _mediaType = MediaType.file;
                        break;
                }
            }

            return _mediaType;
        }
    }
}