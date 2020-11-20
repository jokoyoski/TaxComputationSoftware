using System;
namespace TaxComputationAPI.Manager
{
    public class Bytes4
    {
        public Byte[] Bytes = new Byte[4];
    };

    /// <summary>
    /// AES 
    /// 1 Init 
    /// 2 Encrypt  ,Decrypt  
    /// </summary>
    public class AESProcessor
    {

        #region const definition

        public const Int32 Const_KeyBytes = 16;

        public const Int32 BIT128 = 0;
        public const Int32 BIT192 = 1;
        public const Int32 BIT256 = 2;

        private static Byte[,] Sbox = new Byte[,]
        {  // populate the Sbox matrix
    /* 0     1     2     3     4     5     6     7     8     9     a     b     c     d     e     f */
    /*0*/  {0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76},
    /*1*/  {0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0},
    /*2*/  {0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15},
    /*3*/  {0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75},
    /*4*/  {0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84},
    /*5*/  {0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf},
    /*6*/  {0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8},
    /*7*/  {0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2},
    /*8*/  {0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73},
    /*9*/  {0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb},
    /*a*/  {0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79},
    /*b*/  {0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08},
    /*c*/  {0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a},
    /*d*/  {0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e},
    /*e*/  {0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf},
    /*f*/  {0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16}
        };

        private static Byte[,] iSbox = new Byte[,]
        {  // populate the iSbox matrix
    /* 0     1     2     3     4     5     6     7     8     9     a     b     c     d     e     f */
    /*0*/  {0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb},
    /*1*/  {0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb},
    /*2*/  {0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e},
    /*3*/  {0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25},
    /*4*/  {0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92},
    /*5*/  {0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84},
    /*6*/  {0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06},
    /*7*/  {0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b},
    /*8*/  {0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73},
    /*9*/  {0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e},
    /*a*/  {0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b},
    /*b*/  {0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4},
    /*c*/  {0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f},
    /*d*/  {0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef},
    /*e*/  {0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61},
    /*f*/  {0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d}
        };


        private static Byte[,] Rcon = new Byte[,]
        {
            {0x00, 0x00, 0x00, 0x00},
            {0x01, 0x00, 0x00, 0x00},
            {0x02, 0x00, 0x00, 0x00},
            {0x04, 0x00, 0x00, 0x00},
            {0x08, 0x00, 0x00, 0x00},
            {0x10, 0x00, 0x00, 0x00},
            {0x20, 0x00, 0x00, 0x00},
            {0x40, 0x00, 0x00, 0x00},
            {0x80, 0x00, 0x00, 0x00},
            {0x1b, 0x00, 0x00, 0x00},
            {0x36, 0x00, 0x00, 0x00}
        };

        #endregion

        #region private members

        private Int32 Nb = 0;
        private Int32 Nk = 0;
        private Int32 Nr = 0;
        private Byte[] key = null;// the seed key. size will be 4 * keySize from ctor.

        private Bytes4[] w = null;

        private Bytes4[] State = null;
        private Byte[] m_AesKey = new Byte[16];


        #endregion

        #region private functions


        private static byte gfmultby01(byte b)
        {
            return b;
        }

        private static byte gfmultby02(byte b)
        {
            if (b < 0x80)
            {
                return (byte)((b & 0xFF) << 1);
            }


            //int usint = ByteToUnsigned(b);
            byte ret = (byte)((int)((b & 0xFF) << 1) ^ (int)(0x1b));
            return ret;
        }

        private static byte gfmultby03(byte b)
        {
            byte ret = gfmultby02(b);
            ret = (byte)((int)ret ^ (int)b);
            return ret;
        }

        private static byte gfmultby09(byte b)
        {
            return (byte)((int)gfmultby02(gfmultby02(gfmultby02(b))) ^ (int)b);
        }

        private static byte gfmultby0b(byte b)
        {
            return (byte)((int)gfmultby02(gfmultby02(gfmultby02(b))) ^
                             (int)gfmultby02(b) ^
                             (int)b);
        }

        private static byte gfmultby0d(byte b)
        {
            byte ret1 = gfmultby02(b);
            byte ret2 = gfmultby02(ret1);
            byte ret3 = gfmultby02(ret2);
            return (byte)((int)ret3 ^ (int)ret2 ^ (int)(b));
        }

        private static byte gfmultby0e(byte b)
        {
            byte ret1 = gfmultby02(b);
            byte ret2 = gfmultby02(ret1);
            byte ret3 = gfmultby02(ret2);

            return (byte)((int)ret3 ^ (int)ret2 ^ (int)ret1);
        }


        private byte[] RotWord(byte[] word)
        {
            byte[] result = new byte[4];
            result[0] = word[1];
            result[1] = word[2];
            result[2] = word[3];
            result[3] = word[0];
            return result;
        }

        private byte[] SubWord(byte[] word)
        {
            byte[] result = new byte[4];
            Int32 row, col;
            for (int i = 0; i < 4; ++i)
            {
                row = (word[i] & 0xFF) >> 4;
                col = word[i] & 0x0f;
                result[i] = Sbox[row, col];
            }
            return result;
        }

        private void AddRoundKey(int round)
        {
            for (int r = 0; r < 4; ++r)
            {
                for (int c = 0; c < 4; ++c)
                {
                    State[r].Bytes[c] = (byte)((int)State[r].Bytes[c] ^ (int)w[(round * 4) + c].Bytes[r]);
                }
            }
        }

        private void SubBytes()
        {
            Int32 row = 0;
            Int32 col = 0;
            for (int r = 0; r < 4; ++r)
            {
                for (int c = 0; c < 4; ++c)
                {
                    row = (State[r].Bytes[c] & 0xFF) >> 4;
                    col = State[r].Bytes[c] & 0x0f;
                    State[r].Bytes[c] = Sbox[row, col];
                }
            }
        }

        private void InvSubBytes()
        {
            Int32 row = 0;
            Int32 col = 0;
            for (int r = 0; r < 4; ++r)
            {
                for (int c = 0; c < 4; ++c)
                {
                    row = (State[r].Bytes[c] & 0xFF) >> 4;
                    col = State[r].Bytes[c] & 0x0f;
                    State[r].Bytes[c] = iSbox[row, col];
                }
            }
        }


        private Bytes4[] GetBytes4Ary()
        {
            Bytes4[] temp = new Bytes4[4];
            for (int r = 0; r < 4; ++r)  // copy State into temp[]
            {
                temp[r] = new Bytes4();
            }
            return temp;
        }

        //复制4字节数组里每个元素
        private void CopyBytes(Bytes4[] src, Bytes4[] dest)
        {
            for (int r = 0; r < 4; ++r)
            {
                for (int c = 0; c < 4; ++c)
                {
                    dest[r].Bytes[c] = src[r].Bytes[c];
                }
            }
        }

        private void ShiftRows()
        {
            Bytes4[] temp = GetBytes4Ary();
            CopyBytes(State, temp);// copy State into temp[]

            for (int r = 1; r < 4; ++r)  // shift temp into State
            {
                for (int c = 0; c < 4; ++c)
                {
                    State[r].Bytes[c] = temp[r].Bytes[(c + r) % Nb];
                }
            }
        }

        private void InvShiftRows()
        {
            Bytes4[] temp = GetBytes4Ary();
            CopyBytes(State, temp);// copy State into temp[]

            for (int r = 1; r < 4; ++r)  // shift temp into State
            {
                for (int c = 0; c < 4; ++c)
                {
                    State[r].Bytes[(c + r) % Nb] = temp[r].Bytes[c];
                }
            }
        }

        private void MixColumns()
        {
            Bytes4[] temp = GetBytes4Ary();
            CopyBytes(State, temp);

            for (int c = 0; c < 4; ++c)
            {
                State[0].Bytes[c] = (byte)((int)gfmultby02(temp[0].Bytes[c]) ^ (int)gfmultby03(temp[1].Bytes[c]) ^
                                                                     (int)gfmultby01(temp[2].Bytes[c]) ^ (int)gfmultby01(temp[3].Bytes[c]));
                State[1].Bytes[c] = (byte)((int)gfmultby01(temp[0].Bytes[c]) ^ (int)gfmultby02(temp[1].Bytes[c]) ^
                                                                     (int)gfmultby03(temp[2].Bytes[c]) ^ (int)gfmultby01(temp[3].Bytes[c]));
                State[2].Bytes[c] = (byte)((int)gfmultby01(temp[0].Bytes[c]) ^ (int)gfmultby01(temp[1].Bytes[c]) ^
                                                                     (int)gfmultby02(temp[2].Bytes[c]) ^ (int)gfmultby03(temp[3].Bytes[c]));
                State[3].Bytes[c] = (byte)((int)gfmultby03(temp[0].Bytes[c]) ^ (int)gfmultby01(temp[1].Bytes[c]) ^
                                                                     (int)gfmultby01(temp[2].Bytes[c]) ^ (int)gfmultby02(temp[3].Bytes[c]));
            }
        }

        private void InvMixColumns()
        {
            Bytes4[] temp = GetBytes4Ary();
            CopyBytes(State, temp);


            for (int c = 0; c < 4; ++c)
            {
                State[0].Bytes[c] = (byte)((int)gfmultby0e(temp[0].Bytes[c]) ^ (int)gfmultby0b(temp[1].Bytes[c]) ^
                                           (int)gfmultby0d(temp[2].Bytes[c]) ^ (int)gfmultby09(temp[3].Bytes[c]));
                State[1].Bytes[c] = (byte)((int)gfmultby09(temp[0].Bytes[c]) ^ (int)gfmultby0e(temp[1].Bytes[c]) ^
                                           (int)gfmultby0b(temp[2].Bytes[c]) ^ (int)gfmultby0d(temp[3].Bytes[c]));
                State[2].Bytes[c] = (byte)((int)gfmultby0d(temp[0].Bytes[c]) ^ (int)gfmultby09(temp[1].Bytes[c]) ^
                                           (int)gfmultby0e(temp[2].Bytes[c]) ^ (int)gfmultby0b(temp[3].Bytes[c]));
                State[3].Bytes[c] = (byte)((int)gfmultby0b(temp[0].Bytes[c]) ^ (int)gfmultby0d(temp[1].Bytes[c]) ^
                                           (int)gfmultby09(temp[2].Bytes[c]) ^ (int)gfmultby0e(temp[3].Bytes[c]));

            }
        }

        #endregion

        #region public functions


        private static AESProcessor m_instance = null;
        /// <summary>
        /// 单件模式
        /// </summary>
        /// <returns></returns>
        public static AESProcessor GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new AESProcessor();
            }
            return m_instance;
        }

        public AESProcessor()
        {
            key = null;
            w = new Bytes4[4];
            State = new Bytes4[4];
            for (Int32 i = 0; i < 4; i++)
            {
                w[i] = new Bytes4();
                State[i] = new Bytes4();
            }
        }

        /// <summary>
        /// 是否设置过密钥
        /// </summary>
        private Boolean m_InitedRootKey = false;
        /// <summary>
        /// 初始化密钥
        /// </summary>
        /// <param name="aeskey"></param>
        /// <param name="keysize"></param>
        public void InitKey(Byte[] aeskey, Int32 keysize = BIT128)
        {
            if (aeskey == null || aeskey.Length < Const_KeyBytes)
            {
                return;
            }

            //密钥没改变,不做任何处理
            Boolean bl = false;
            if (m_InitedRootKey) //2017-08-23 zhengjf
            {
                bl = BytesEqual(m_AesKey, 0, aeskey, 0, Const_KeyBytes);
                if (bl)
                {
                    return;
                }
            }

            Array.Copy(aeskey, m_AesKey, Const_KeyBytes);

            Nb = 4;
            switch (keysize)
            {
                case BIT128:
                    Nk = 4;
                    Nr = 10;
                    break;
                case BIT192:
                    Nk = 6;
                    Nr = 12;
                    break;
                case BIT256:
                default:
                    Nk = 8;
                    Nr = 14;
                    break;
            }

            key = new Byte[Nk * 4];
            Array.Copy(aeskey, key, key.Length);

            Int32 wlen = Nb * (Nr + 1);
            w = new Bytes4[wlen];
            for (Int32 i = 0; i < w.Length; ++i)
            {
                w[i] = new Bytes4();
            }

            for (int row = 0; row < Nk; ++row)
            {
                w[row].Bytes[0] = key[4 * row];
                w[row].Bytes[1] = key[4 * row + 1];
                w[row].Bytes[2] = key[4 * row + 2];
                w[row].Bytes[3] = key[4 * row + 3];
            }

            Byte[] temp = new Byte[4];
            for (int row = Nk; row < wlen; ++row)
            {
                temp[0] = w[row - 1].Bytes[0];
                temp[1] = w[row - 1].Bytes[1];
                temp[2] = w[row - 1].Bytes[2];
                temp[3] = w[row - 1].Bytes[3];
                if (row % Nk == 0)
                {
                    temp = SubWord(RotWord(temp));//this change two size
                    temp[0] = (Byte)((int)temp[0] ^ (int)Rcon[row / Nk, 0]);
                    temp[1] = (Byte)((int)temp[1] ^ (int)Rcon[row / Nk, 1]);
                    temp[2] = (Byte)((int)temp[2] ^ (int)Rcon[row / Nk, 2]);
                    temp[3] = (Byte)((int)temp[3] ^ (int)Rcon[row / Nk, 3]);
                }
                else if (Nk > 6 && (row % Nk == 4))
                {
                    temp = SubWord(temp);
                }

                // w[row] = w[row-Nk] xor temp
                w[row].Bytes[0] = (Byte)((int)w[row - Nk].Bytes[0] ^ (int)temp[0]);
                w[row].Bytes[1] = (Byte)((int)w[row - Nk].Bytes[1] ^ (int)temp[1]);
                w[row].Bytes[2] = (Byte)((int)w[row - Nk].Bytes[2] ^ (int)temp[2]);
                w[row].Bytes[3] = (Byte)((int)w[row - Nk].Bytes[3] ^ (int)temp[3]);
            }//loop

            m_InitedRootKey = true;
        }

        #endregion

        #region Encrypt

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="rawdata">明文</param>
        /// <param name="ciphertext">密文</param>
        /// <returns></returns>
        public Byte[] Encrypt(Byte[] rawdata)
        {
            Byte[] ret = null;
            Boolean bl = Encrypt(rawdata, ref ret);
            if (!bl)
            {
                return null;
            }

            return ret;
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="rawdata">明文</param>
        /// <param name="ciphertext">密文</param>
        /// <returns></returns>
        public Byte[] Encrypt(Byte[] rawdata, Byte[] key)
        {
            InitKey(key);
            return Encrypt(rawdata);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="rawdata">明文</param>
        /// <param name="ciphertext">密文</param>
        /// <returns></returns>
        public Boolean Encrypt(Byte[] rawdata, ref Byte[] ciphertext)
        {
            if (rawdata == null || rawdata.Length != Const_KeyBytes)
            {
                return false;
            }
            if (ciphertext == null || ciphertext.Length != Const_KeyBytes)
            {
                ciphertext = new Byte[16];
            }

            for (int i = 0; i < (4 * Nb); ++i)
            {
                State[i % 4].Bytes[i / 4] = rawdata[i];
            }
            AddRoundKey(0);

            for (int round = 1; round <= (Nr - 1); ++round)  // main round loop
            {
                SubBytes();
                ShiftRows();
                MixColumns();
                AddRoundKey(round);
            }  // main round loop

            SubBytes();
            ShiftRows();
            AddRoundKey(Nr);

            // ciphertext = state
            for (int i = 0; i < (4 * Nb); ++i)
            {
                ciphertext[i] = State[i % 4].Bytes[i / 4];
            }
            return true;
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="rawdata">明文</param>
        /// <param name="ciphertext">密文</param>
        /// <returns></returns>
        public Boolean Encrypt(Byte[] rawdata, Int32 srcoffset, ref Byte[] ciphertext, Int32 destoffset)
        {
            if (rawdata == null || ciphertext == null ||
                srcoffset < 0 || destoffset < 0 ||
                srcoffset + 16 > rawdata.Length || destoffset + 16 > ciphertext.Length)
            {
                return false;
            }

            Byte[] rawbytes = new byte[16];
            Byte[] keybytes = new Byte[16];

            Array.Copy(rawdata, srcoffset, rawbytes, 0, 16);
            Encrypt(rawbytes, ref keybytes);
            Array.Copy(keybytes, 0, ciphertext, destoffset, 16);
            return true;
        }

        #endregion


        #region Decrypt

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="rawdata"></param>
        public Byte[] Decrypt(Byte[] ciphertext)
        {
            Byte[] rawdata = null;
            Boolean bl = Decrypt(ciphertext, ref rawdata);
            if (!bl)
            {
                return null;
            }

            return rawdata;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="rawdata"></param>
        public Byte[] Decrypt(Byte[] ciphertext, Byte[] key)
        {
            InitKey(key);
            return Decrypt(ciphertext);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="rawdata"></param>
        public Boolean Decrypt(Byte[] ciphertext, ref Byte[] rawdata)
        {
            if (ciphertext == null || ciphertext.Length != Const_KeyBytes)
            {
                return false;
            }
            if (rawdata == null || rawdata.Length != Const_KeyBytes)
            {
                rawdata = new Byte[Const_KeyBytes];
            }

            for (int i = 0; i < (4 * Nb); ++i)
            {
                State[i % 4].Bytes[i / 4] = ciphertext[i];//State[i % 4][ i / 4] 
            }

            AddRoundKey(Nr);
            //String str = GetStateString();
            for (int round = Nr - 1; round >= 1; --round)  // main round loop
            {
                InvShiftRows();
                InvSubBytes();
                AddRoundKey(round);
                InvMixColumns();
            }  // end main round loop for InvCipher

            InvShiftRows();
            InvSubBytes();
            AddRoundKey(0);

            // rawdata = state
            for (int i = 0; i < (4 * Nb); ++i)
            {
                rawdata[i] = State[i % 4].Bytes[i / 4];//State[i % 4][ i / 4];
            }
            return true;
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="ciphertext">密文</param>
        /// <param name="rawdata">明文</param>
        /// <returns></returns>
        public Boolean Decrypt(Byte[] ciphertext, Int32 srcoffset, ref Byte[] rawdata, Int32 destoffset)
        {
            if (rawdata == null || ciphertext == null ||
                srcoffset < 0 || destoffset < 0 ||
                srcoffset + 16 > ciphertext.Length || destoffset + 16 > rawdata.Length)
            {
                return false;
            }

            Byte[] rawbytes = new byte[16];
            Byte[] keybytes = new Byte[16];

            Array.Copy(ciphertext, srcoffset, keybytes, 0, 16);
            Decrypt(keybytes, ref rawbytes);
            Array.Copy(rawbytes, 0, rawdata, destoffset, 16);
            return true;
        }


        #endregion

        #region auxiliary function

        /// <summary>
        /// 判断2个数组指定内容是否一致
        /// </summary>
        /// <param name="bytes1"></param>
        /// <param name="bytes2"></param>
        /// <returns></returns>
        public static Boolean BytesEqual(Byte[] bytes1, Int32 start1,
            Byte[] bytes2, Int32 start2, Int32 len)
        {
            if (bytes1 == null || start1 < 0 || start1 >= bytes1.Length ||
                bytes2 == null || start2 < 0 || start2 >= bytes2.Length ||
                len < 1 || start1 + len > bytes1.Length || start2 + len > bytes2.Length)
            {
                return false;
            }

            for (Int32 idx = 0; idx < len; ++idx)
            {
                if (bytes1[idx + start1] != bytes2[idx + start2])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

    }
}







