﻿using System.ComponentModel;

namespace Utils.APICaller
{
    public enum ContentType
    {
        None = 0,
        [Description("application/json")]
        ApplicationJson = 1,

        [Description("text/plain")]
        Text = 2,

        [Description("multipart/form-data")]
        FormData = 3
    }
}
