﻿/**
 * Copyright (c) 2018, 1Kosmos Inc. All rights reserved.
 * Licensed under 1Kosmos Open Source Public License version 1.0 (the "License");
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of this license at 
 *    https://github.com/1Kosmos/1Kosmos_License/blob/main/LICENSE.txt
 */

namespace BIDHelpers.BIDVerifyDocument.Model
{
    public class BIDPollSessionResponse
    {
        public string responseStatus;
        public string sessionId;
        public object metadata;
        public BIDDLObjectData dl_object;
        public BIDLiveIdObjectData liveid_object;
        public string data;
        public string publicKey;
        public string token;
        public string message;
        public bool status;

    }
}
