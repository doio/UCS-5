/*
 * Program : Ultrapowa Clash Server
 * Description : A C# Writted 'Clash of Clans' Server Emulator !
 *
 * Authors:  Jean-Baptiste Martin <Ultrapowa at Ultrapowa.com>,
 *           And the Official Ultrapowa Developement Team
 *
 * Copyright (c) 2016  UltraPowa
 * All Rights Reserved.
 */
// IMatchFinder.cs

using System;

namespace UCS.Core.Crypto.LZMA.Compress.LZ
{
    internal interface IInWindowStream
    {
        void SetStream(System.IO.Stream inStream);

        void Init();

        void ReleaseStream();

        Byte GetIndexByte(Int32 index);

        UInt32 GetMatchLen(Int32 index, UInt32 distance, UInt32 limit);

        UInt32 GetNumAvailableBytes();
    }

    internal interface IMatchFinder : IInWindowStream
    {
        void Create(UInt32 historySize, UInt32 keepAddBufferBefore,
                UInt32 matchMaxLen, UInt32 keepAddBufferAfter);

        UInt32 GetMatches(UInt32[] distances);

        void Skip(UInt32 num);
    }
}