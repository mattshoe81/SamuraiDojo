using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Battles.Week4;
using SamuraiDojo.Test.Attributes;

namespace SamuraiDojo.Test.Week4
{
    [UnderTest(typeof(Palindromania))]
    [TestClass]
    public abstract class PalindromaniaTest : DojoTest<Palindromania>
    {

        private void AssertExpected(string input, string expected)
        {
            string actual = GetInstance().LargestPalindrome(input).ToUpper();
            Assert.AreEqual(expected.ToUpper(), actual, $"{Environment.NewLine}Expected:\t{expected.ToUpper()}{Environment.NewLine}Found:\t{actual}");
        }

        [TestMethod]
        public override void Benchmark()
        {
            AssertExpected(
                @"yg^:L46yJeE`rC)C<y55Rcc]]C)VttEC0D*9;{`vc&tp2i{**goc[#6%!x6.+y~@WVJnM3,,]p7ggcVrP4Ps5{yZ4VKF(?gzl]Ug\L>Z\%`V\IZL@=Lrul|-?(<jmg1?Gs1C1v1{'G`2*:bOA9/8]0o|!e^mIDx>7io@w{eNU*$ej}r}ud0o&G*84*@uEf'+-L1{9X5P)5_fH%'A[%TON/iGf*w-Mmb6pKiq?O$J5^}onoA-7ld({vUv>OL<$I0(%OWi1>/A-QG%&(v3E{V\ufdH5z0No0{\b%vf$e*lJZna@iqM|<K~'q,{6ZO;,Yzz3fnwUtOo{]Oxbz$d6;(j+0DR{L[RV&Ky\R\CO)g%(U/JD)Iq.'@VSWMo+>!=yVF,(s+-l1jVpZCX~No|iV*{2Smf^JT:^Y_K//x5&3H8#R*A?-:^X_uY#T:x)1?6Im)y{be:.I\`0,PLTvw}_|(fT[.sH']bsXCS}]97,y[`GJ61Hb(fr3mkA'X5yp4i*$,F<x/[^j2NiIm-o)d\ogf~}_L.:v#=HF*5W&9.@wOZ3lLl4r,|.\049bKU'OT.FD;66#!{&r:!z~bJ5S\m%Hac[@8W#W8@[caH%m\S5Jb~z!:r&{!#66;DF.TO'UKb940\.|,r4lLl3ZOw@.9&W5*FH=#v:.L_}~fgo\d)o-mIiN2j^[/x<F,$*i4py5X'Akm3rf(bH16JG`[y,79]}SCXsb]'Hs.[Tf(|_}wvTLP,0`\I.:eb{y)mI6?1)x:T#Yu_X^:-?A*R#8H3&5x//K_Y^:TJ^fmS2{*Vi|oN~XCZpVj1l-+s(,FVy=!>+oMWSV@'.qI)DJ/U(%g)OC\R\yK&VR[L{RD0+j(;6d$zbxO]{oOtUwnf3zzY,;OZ6{,q'~K<|Mqi@anZJl*e$fv%b\{0oN0z5Hdfu\V{E3v(&%GQ-A/>1iWO%(0I$<LO>vUv{(dl7-Aono}^5J$O?qiKp6bmM-w*fGi/NOT%[A'%Hf_5)P5X9{1L-+'fEu@*48*G&o0du}r}je$*UNe{w@oi7>xDIm^e!|o0]8/9AOb:*2`G'{1v1C1sG?1gmj<(?-|lurL=@LZI\V`%\Z>L\pq8?yrSxX-S.1SNaf_v0fPO}^Jy@suD~zh`C{ZAOUA:TpX:FfQeYfW4AC:_Pw3-bhT2Hq,e,?HZE6y-'1SYC1i8CT@~aypVC5Wk=",
                @"\L>Z\%`V\IZL@=Lrul|-?(<jmg1?Gs1C1v1{'G`2*:bOA9/8]0o|!e^mIDx>7io@w{eNU*$ej}r}ud0o&G*84*@uEf'+-L1{9X5P)5_fH%'A[%TON/iGf*w-Mmb6pKiq?O$J5^}onoA-7ld({vUv>OL<$I0(%OWi1>/A-QG%&(v3E{V\ufdH5z0No0{\b%vf$e*lJZna@iqM|<K~'q,{6ZO;,Yzz3fnwUtOo{]Oxbz$d6;(j+0DR{L[RV&Ky\R\CO)g%(U/JD)Iq.'@VSWMo+>!=yVF,(s+-l1jVpZCX~No|iV*{2Smf^JT:^Y_K//x5&3H8#R*A?-:^X_uY#T:x)1?6Im)y{be:.I\`0,PLTvw}_|(fT[.sH']bsXCS}]97,y[`GJ61Hb(fr3mkA'X5yp4i*$,F<x/[^j2NiIm-o)d\ogf~}_L.:v#=HF*5W&9.@wOZ3lLl4r,|.\049bKU'OT.FD;66#!{&r:!z~bJ5S\m%Hac[@8W#W8@[caH%m\S5Jb~z!:r&{!#66;DF.TO'UKb940\.|,r4lLl3ZOw@.9&W5*FH=#v:.L_}~fgo\d)o-mIiN2j^[/x<F,$*i4py5X'Akm3rf(bH16JG`[y,79]}SCXsb]'Hs.[Tf(|_}wvTLP,0`\I.:eb{y)mI6?1)x:T#Yu_X^:-?A*R#8H3&5x//K_Y^:TJ^fmS2{*Vi|oN~XCZpVj1l-+s(,FVy=!>+oMWSV@'.qI)DJ/U(%g)OC\R\yK&VR[L{RD0+j(;6d$zbxO]{oOtUwnf3zzY,;OZ6{,q'~K<|Mqi@anZJl*e$fv%b\{0oN0z5Hdfu\V{E3v(&%GQ-A/>1iWO%(0I$<LO>vUv{(dl7-Aono}^5J$O?qiKp6bmM-w*fGi/NOT%[A'%Hf_5)P5X9{1L-+'fEu@*48*G&o0du}r}je$*UNe{w@oi7>xDIm^e!|o0]8/9AOb:*2`G'{1v1C1sG?1gmj<(?-|lurL=@LZI\V`%\Z>L\"
            );
        }

        [TestMethod]
        public void TestMethod1()
        {
            AssertExpected(
                "XYX",
                "XYX"
            );
        }

        [TestMethod]
        public void TestMethod2()
        {
            AssertExpected(
                "X",
                "X"
            );
        }

        [TestMethod]
        public void TestMethod3()
        {
            AssertExpected(
                "XYX7",
                "XYX"
            );
        }

        [TestMethod]
        public void TestMethod4()
        {
            AssertExpected(
                "7X7Z",
                "7X7"
            );
        }

        [TestMethod]
        public void TestMethod5()
        {
            AssertExpected(
                "123456789",
                "1"
            );
        }

        [TestMethod]
        public void TestMethod6()
        {
            AssertExpected(
                "XYYX",
                "XYYX"
            );
        }

        [TestMethod]
        public void TestMethod7()
        {
            AssertExpected(
                "XYYX89",
                "XYYX"
            );
        }

        [TestMethod]
        public void TestMethod8()
        {
            AssertExpected(
                "1234567899",
                "99"
            );
        }

        [TestMethod]
        public void TestMethod9()
        {
            AssertExpected(
                ".@#$%^&*",
                "."
            );
        }

        [TestMethod]
        public void TestMethod10()
        {
            AssertExpected(
                ".@#$%^&**",
                "**"
            );
        }

        [TestMethod]
        public void TestMethod11()
        {
            AssertExpected(
                ".@#$$%^&*",
                "$$"
            );
        }

        [TestMethod]
        public void TestMethod12()
        {
            AssertExpected(
                ".@#$$%^&**",
                "$$"
            );
        }

        [TestMethod]
        public void TestMethod13()
        {
            AssertExpected(
                "XYyZz",
                "yy"
            );
        }

        [TestMethod]
        public void TestMethod14()
        {
            AssertExpected(
                "asdfghjkllqwertyuiop",
                "ll"
            );
        }

        [TestMethod]
        public void TestMethod15()
        {
            AssertExpected(
                "asdfghjkllqwerrtyuiopp",
                "ll"
            );
        }

        [TestMethod]
        public void TestMethod16()
        {
            AssertExpected(
                "asdfghjkllqwerrrtyuiopp",
                "rrr"
            );
        }

        [TestMethod]
        public void TestMethod17()
        {
            AssertExpected(
                @"jdwU55-]*5L1FR-JdL]G-dXDAFX*_g387x~n'<b!l`Yd1_52fep.,_AjT}qw5x?cx]oZcs1UYi'MO-B3>m$~K-t(Tcb7q=ir/*pRrS~id=:!ftO75c5}lMlj0b.c]uqqu]c.b0jlMl}5c57Otf!:=di~SrRp*/ri=q7bcT(t-K~$m>3B-GHsy)&\Ym>k-tTFB7W[aMR'j}]#|D1jLrxd}iQ[DOwWr`)5*fq}}<#=tB*zK$_6]R@9znGXdz83Ty3+uIx7Q2l0o",
                @"-B3>m$~K-t(Tcb7q=ir/*pRrS~id=:!ftO75c5}lMlj0b.c]uqqu]c.b0jlMl}5c57Otf!:=di~SrRp*/ri=q7bcT(t-K~$m>3B-"
            );
        }

        [TestMethod]
        public void TestMethod18()
        {
            AssertExpected(
                @"TgWYh9jvHnui'bw(Mh&1@Zs6if'mVeWe/BwD==$eRRNKtj`PncIKMFNM-tul}=Iv:kTf3gjv5RWm)x+_T&,!]pRc*,,)499*AVL!K5Uzc'=~~='czU5K!LVA*994),,*cRp]!,&T_+x)mWR5vjg3fTk:vI=}lu,7fsb-xIx",
                @"ul}=Iv:kTf3gjv5RWm)x+_T&,!]pRc*,,)499*AVL!K5Uzc'=~~='czU5K!LVA*994),,*cRp]!,&T_+x)mWR5vjg3fTk:vI=}lu"
            );
        }

        [TestMethod]
        public void TestMethod19()
        {
            AssertExpected(
                @"oG>~ceB*A7,1;i>1+.q3&3Bd'I9uo,_W4%,GrK)3\O[sh|y#<I]@)cX{n1Jkx}Y|+t/6kYZhMzu]/1uQ63sJ)jLC:w!M4U.R.j%_O151rf+T'qsn^]B(Qgh0T^F!iMOXO{P$~T0W:F2pyxx_xjyc/]N]m%4^hNV&X%U(RmYXBPd!EV4h>/O@R(]&%%&](R@O/>h4VE!dPBXYmR(U%X&VNh^4%m]N]/cyjx_xxyp2F:W0T~$P{OXOMi!F^T0hgQ(B]^nsq'T+fr151O_%j.R.U4M!w:CLj)SO",
                @")jLC:w!M4U.R.j%_O151rf+T'qsn^]B(Qgh0T^F!iMOXO{P$~T0W:F2pyxx_xjyc/]N]m%4^hNV&X%U(RmYXBPd!EV4h>/O@R(]&%%&](R@O/>h4VE!dPBXYmR(U%X&VNh^4%m]N]/cyjx_xxyp2F:W0T~$P{OXOMi!F^T0hgQ(B]^nsq'T+fr151O_%j.R.U4M!w:CLj)"
            );
        }

        [TestMethod]
        public void TestMethod20()
        {
            AssertExpected(
                @"x`v-kN8Ek[c0dtJ/Gg#V:x[|kKN'65ib[g\.8w0k_H,GEg@?#6~>o@X^m/&z;vlw$*w%5MDF'ruq_J,pFh}$-mkTkqZ[>6_U;kqQYeeYQqk;U_6>[ZqkTkm-$}hFp,J_qur'FDM5%w*$wlv;z&/m^X@o>~6#?@gEG,H_k0w8.\g[bi56'NKk|[x:V#gG/Jtd0c[kE8Nk-v`pc.Si~zp",
                @"`v-kN8Ek[c0dtJ/Gg#V:x[|kKN'65ib[g\.8w0k_H,GEg@?#6~>o@X^m/&z;vlw$*w%5MDF'ruq_J,pFh}$-mkTkqZ[>6_U;kqQYeeYQqk;U_6>[ZqkTkm-$}hFp,J_qur'FDM5%w*$wlv;z&/m^X@o>~6#?@gEG,H_k0w8.\g[bi56'NKk|[x:V#gG/Jtd0c[kE8Nk-v`"
            );
        }

        [TestMethod]
        public void TestMethod21()
        {
            AssertExpected(
                @"=vQ3>;HMY=>Bq{qwHvf<uK*F!xFJ7@Pc#*+e@j#6byiv~~2_%}h$k?%G]q}AQ+HD5>A$[uv2zSZyrg9};vT_cd#D.e\8||i>t]^9}}9^]t>i||8\e.D#dc_Tv;}9gryZSz2vu[$A>5DH+QA}q]G%?k$h}%_2~~viyb6#j@e+*#cP@7JFx!F*Ku<fvHwq{qB>=YMH;>3Qv=",
                @"=vQ3>;HMY=>Bq{qwHvf<uK*F!xFJ7@Pc#*+e@j#6byiv~~2_%}h$k?%G]q}AQ+HD5>A$[uv2zSZyrg9};vT_cd#D.e\8||i>t]^9}}9^]t>i||8\e.D#dc_Tv;}9gryZSz2vu[$A>5DH+QA}q]G%?k$h}%_2~~viyb6#j@e+*#cP@7JFx!F*Ku<fvHwq{qB>=YMH;>3Qv="
            );
        }
    }
}
