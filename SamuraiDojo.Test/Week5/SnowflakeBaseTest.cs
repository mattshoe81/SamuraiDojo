using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Test.Attributes;
using SamuraiDojo.Battles.Week5;

namespace SamuraiDojo.Test
{
    [UnderTest(typeof(Snowflake))]
    [TestClass]
    public abstract class SnowflakeTestBase : DojoTest<Snowflake>
    {

        private void AssertExpected(string input, char expected)
        {
            char actual = GetInstance().FindFirstUniqueCharacter(input);
            Assert.AreEqual(expected, actual, $"{Environment.NewLine}Expected:\t{expected.ToString()}{Environment.NewLine}Found:\t{actual.ToString()}");
        }

        [TestMethod]
        public override void Benchmark()
        {
            AssertExpected(
                @"?n3B)^BGA)JG4T}:WJqS*Y]JX~/{ujb{AX+Uwu&VTl>x#Gg%PyvWKcyX$^0L]@b(<K1k;Qyl34`{BIgl)RTY;TMh%,+uls'dP%XNxE_$N!-#6CMMLA:zn%#GuKetAW9C2$ghy[a^$c5m\gC0w:Cz(7])d*0-$P30Gx>KcT'SN2cjU.ihhf,K=u3m=b`ItI@}}SvMS=`~V6)T`(`uBI>LI`91gCcoi;Od%!yG<Itye[/_-*V6X`&W<;aTE;Mr9U!.92.T|_$UKX0qk'v[Qzrl,{(b4Op`8ITBB}Q5Bi?h8(-#h@t6`-D<9OM]Wy15jo\8WL7%}0;l?y^bFO9Y+K'\z<g=v5g*4>}u7]T/nw_~8gSm\C[*t(l7JBK{dJ\bkvrhg};-L5'=q\OxDAon&.8U7mxfYq1EI5O^8]i0|xx\R=_L)_.D<?@+ABPwbOx;+QTAD8$&B~,%=5%(X?[px%W#i`@\%9#ExUrh&;~_VT_\x2<(SV4]A{c)YENB]T\Pm_|?'X)u0gPP^^x>C\hRG8qk&K^^k>c~;HVe./Q6u2W:.[lSEY.t>mjSCDtKE.r8|gxz?^T]$mrKhmBb.1j/;1CDByf#DS5%w$zo<<r}=kzxsXc,xB6=a,D'F#xMsh))B{n:8./)0~jL;Y|W%u2DhG(NMTKbBovYRgrUxv%\62$jy3,}qCv7L`PpZsI\,U@),M3c8N4,.?Ed+&GZ86uYQ00J!e<B$3Gp[I3`lDG%:j]UVcAfjVPN>-m-53-6(c_9J~{^s+U8TGwM&JL|q_YTD0=D,{\h<'(]2_jD^xS&9xx]bgy[Kk$qAk#4V&Ot4GLY)Dc=zFdrcF0CC8qKnoU)G?Pzt/x:bvB-]iu4rl#%1Eov(:#ZxgRXJ]WbjG],U:\gm04S1h=qFz)f7M>B\i#R<G1ELFQ:`IS;$mTs~uZn_fFL!NZ7S4qcO+^2ANY~?x5gze:dRI-IjQuB$'AU;D:w.jv^>jOdYTBzG(hfDZ.;hlB}i+&U76TH:TEs9*l${sZ,$NNqL')tNMzfB!-}MqRE;!SavxSC@F>Z5:77o]*)hp)dq~e[fDx[rTUpi:9B)!W\vrh&Q/%d'u)v4]niy)tI:`IV;9aEU@c,eX[4C-hc2f$YaR|c4$8gbG*dxn=29<)kiU*-Q6WXu/Xx9<<UbH'?nw|0<+tB|%q<Ro}}j2A#.'\i*6Bxyams83Y0Q^b-lx0-;G#kUlD?h!rCxZ#fN>Y7\qIWY>LFh1!(JSqNe<f;/=P?TdjtN(WiJLwyH-X7at,!4mh>5](BbNn.sd8\Q.:/{kAnuQ*{Gg/iwMo1]T(0BI#he{UGA+it9`z9/6V]#_#nQC}q,T['TlAGMRhs=^s>9#F~ENHf0M'0\YwYB26}PwD[r3oN-G.SXx3$~~[st/OGiuyXT|OeBvn*u!m3oFkr/K[[z0kcCU)d#=&DRy$w`Rq*iC#mfBICZWD8J}Y`|7[h3\Bf44Q.r~6I8VC?[Xc=^=bH^)y(Nrlb7qdeG}}.!}?f3}:95kAy'P.w]w,Lk&bL_*Zb|OvBj:KI%D+;uA^M,w]v~8SX~HYde'DiH?JJ&~_csd#&CEIbqDbqWXcESVw=U~x,Z\+23&8cMquJ[D6hgaX-~,(A3*2b2,GH;G'S!87\JW1A=tRAOZef?i[~;sng1yf=hNzgo%38KExiLE0n{>7au~x+<0N9tWb22y{BU|QH2v{|>(DQA\ty~xLe[K]h[=4,_%?eTnF'@VXcQl3lT]mY7^TKAUXxwd4P)gx]S1^I?-O6NwiG8^dy3QSb]6,xhO>'SW<@u/7<X)nr-k|l\*R`?M!+[.l^?C(s5/Nq:jW*41'NC#nbOs'b9)1vDiCZCowW[{towYAPc`wH1j'h0r7`[THJ|0,^W[07e0-xjfa&^[_ApYN96.+6f`McI.[Ik}e*}6Fj2_\Mh>ghxP[wLt|\zV1kfur/Y59I%\W`yly4x/`a[P8G_Xbf_4TR\gfxI7r$6~R}KZUUtP4@#\cPU~PzT[Sd{;#jE{P;;QL['0c|X4<*JIW}N`AQNi03P[YXEu=i${bo.*s(uP+./_Ox/|D>{bXf3M*4:m9d%4+d*oI3?q`i7LH?cVx2(j/L|>v@K3r8Y~zv2[9xY7C;Cw*~TWRk|dFg#J:&BCww~?x3wUb<mzb<=.B4Cw-p;60N!X}BhYCQudKj5@[^v5l%?X7.%98Sa]{SpcgeMbCd<(r'Z5c*6iRV|1hbv9.g3YGpUKDLKynaL:6z4i@xs$F.3N`xV-:f^2}x]:JBSq_yvbo/KO+1to?;O1xftSO^B1#%xJ\;h~+/t`/OAl5xw6}U<1R7$w*bB>}=\yh&g7'n7*UY]dg,c5pZ({;\8v$fa.C'JIIdn!@-v^P,/U>W#(,:$e5!F>Po{##MVJ~{ezq9sw(Gk6H\]>p[*\,!a`MA`wc$Bgw#@/Wn4O%1zLDgm0bl,g'i`U;{-Z_5dGe^b-kA3`;$_apus<c&wO\x}i!3k<>w$)s-Zs&F@D(J'KQBs=w)]DS*|$vi9L^r^YFf\HRw#B^dsa#6RA,au{IYcdI9QSjm:0)6_|kYVW[H3i0eC/wes\x+|_r_/sq1,*.r-$;Q@WkWxd^55La(sjr&,?*Hy*xD=xCdLS#Yg/g)!Tu59&Gzgp5:#WI=gpMI,t01JJ&7t#0pH;B\U]DU@2f@??\TFt<2I4`C9$GA?QHLWU(0pz@ffEx,L1m;sBcoG;QT+QXN~*s23Q%AV]-HL?Gq6Vb@peIs,Jh#4YGQ]EZ8p.M)D6oc1s1;pCS?@VB@N7Z)@`E[`x%!&OtDJ[NEb%BLx,?g&{2=;GP^g|^~w1kX@&=|rY(ajLa,t>e\0}K,l!QPZ_b)dbp'~I0&WhqHs:2ISyBf*${ZZQ:Yc$mn&w(C-H&TxJ#rw[0u0|-QW`/V^EWJJe+4.bHb/_ylgP%O-57ix)$uP|xP/!b_oB_ejzT.FLk^xxha=}d*b7Z8FHiWLrP\X_~z\x6|1<Sw.L.Nz%r2C>*-m'f<?bg7~9z[^'H0M-kx,#dIk<*Oh!,I6vs}?bX$`d@aQ!m]h8uNUQ[Y:z'B66MCr!uz6?lS@4A;|VLpheec316)4Y<`'<_RTLB&aK&}8yyhm4%DI,akEE8Wn=qgQP&zkzO-\[EkR*qTeJ:t^@@{@YtEZe$_QpX3,a=3j7R#{_l44a03\feWjS-,!23<0>uC+EzW}Q$.T<\:4AV,p[7ry%DQ9'Y?Om0QRgp?!b+C`'s<9r<?X$zoH$$n<*2.?2v/MyaUnG%(r<!OsItVM>p(fa;ET=JuP52d#j2\x8-Y3iD77RPPiV+](lvRKuMiN`R[+f?r{*zE.@)#i'l|Sd]:CZJ>)EQxen|w=`c4]v>k~SedpI*I8usC[{Jsd$c,/@l+O_x?\BGf^H5H]Gk&'*A{<AXQhR]1Cul&[O#NW3+cK\`wF;Ib+F'~#aIw^Q>hsJkt6x}xE8+!-@M%/v7t>O3~k$Re%o0+k$!R&/c'>n7lo{3C}kbf6=-|+1KdkW%/A#[dqODe9z6Wml}fRLa!cdufKQPHSB^g=#RI@&(ay&K87MK~`*.;#D?Mh~-INN6~?,'PdO^mIM(DEaSQ&sP<3yfZ'2d21roEl@2,nTFc52N,wXAG`xc7f<bX{x&VR[Krn@S]xx+,<r$s?UKV)^o)sUi<F!Hee2&bYI~vsz:2>kx$kCu;1<Zt{Y)f2Z^/Jl_>7~b`jZM{v;Ui?qubM_V%6ZP%HJ00hL$df_M_Wh:Tem+BemM8:NBovLU(E3[,frWOf=&zdG2Y76x19_WJ|H</3i}vuwmRl\NbA_ioJ,~tNzh&MkUi5NnjuT&~S2/;Nc6O5lqz@yvgK@=yJzx_CZcZvxv~,r\^)mPgFR[9djEJYoW=yyvW`bs\M1#H!_0=cDjm`5/1&lXSC8aho3<[@bT*Xh`$GLha*HB[m*5[XV~R#PAc+'g*+viVXO)wN'hv\_>Kan,3pO$Wr%zVXcXdm:wy9*$8oW$\`uN1g9LJ%#&SDQTL:2Rl,SWHr9-Mc+?1SpTvyRf1FH.S9|@)4P;U6AL]{;M3&Lk9QK~{q0nm.Hqg!x7>F~B5v&YTgZ*{ST9L!(x*TU+oX{3ZV\UQ,/]#vM6619<qodxN-/J]q>mDI/)B/>S)(>SPZQwv)xY*TzDkhUqA1a[{S(eT2i1+.`_mO0OD<LELZA;-U#8;o5XGx}$gr.$gODvDevrH8Z([lI'+=Y7@iIL27h^Ar.^!3$hghCSdjAQwK6?3tRBfE27~N0IzH[)LV<D$3S}L'U5UxbNoP>rXcRT%t[/.nUt2W$cI`sy:J-HR_$rx>ICav/x/4Juf@OVj]G+8[7rY'1:j\BEd2p!0b{kbnHsaHy60,927Y6MN0+j}OF]Fdx#,x4[g_(3]F1Fp.`l?w,cct4n1uxo])3[t:9vO6_0r_$&=JhKWnj{j5rvN^*iS[a$=Fr!z4qBK~Tn=(:C'{L)<>HyaKIhL<Lb8so}F2qR''Yw0+xM}7zv3mE9wi3<xi_,Ws)PItA,W)No,\663k#$>bef9Gs_>?@ox(g7yr]]H?QA~wOZr)x\:f&YrQY~?a{:Svc1ZJl4z]Wk3eCGC3|k%M`XZ8)9b8q!TPG-Z7%(+O1K]svH.*[=Jyh|(tUxK9ftx<$KbBu[5fuI:?I7VkRQc.qlPxWxnN~~:.y<m#I(X~'S3aeiNj/j/Y+x:&{TbWH:3yYnnp5>Pumk}wJ|gFUpaV/5F!5-NwS,\>S-GSm?,$:mQB*:De16giQx--A;~%-Cmzc=yl#2V{KyfBYj0>r@-JglID(C<%\r@WCo}SK&)-t[W}1Rkt{zPo0M(eZiMPw0;~o6)h-<w^ji!15Yr!XfZPp7o%JaE_50!}AG`eJA:xx{a[-K2!wk*o*uL&D1D(^~S8g09Z8yh?Bp5,Fuyw~sGvp^!v<u_ndEU'XJ,.CuJ{32`x#tsB+:4R=tZ45zz!Htm5Wx|Td3hsx!lg|7,hW/pO*WC1'svmIN'(o<&Ex-M102hML~:o`Ro08Mq%",
                '%'
            );
        }

        [TestMethod]
        public void TestMethod1()
        {
            AssertExpected(
                "1",
                '1'
            );
        }

        [TestMethod]
        public void TestMethod2()
        {
            AssertExpected(
                "3333222221",
                '1'
            );
        }

        [TestMethod]
        public void TestMethod3()
        {
            AssertExpected(
                "12323",
                '1'
            );
        }

        [TestMethod]
        public void TestMethod4()
        {
            AssertExpected(
                "35799531",
                '7'
            );
        }

        [TestMethod]
        public void TestMethod5()
        {
            AssertExpected(
                "155233",
                '1'
            );
        }

        [TestMethod]
        public void TestMethod6()
        {
            AssertExpected(
                @"`FkkBoZjPhV}=$B+fk&l{mGLx6ae;?<kZiP5{IWD/f=(l+h2IL|!N/ea6x=Q};;^*vKWQ0pqo5Z[NC*A/>Lw27|i@/Sdt*__i@Czol1?(Kr1*@!SWHazubqP<R@\9x<eMk!i*B+^-Uj&,9mHb%TLrQ&p2YTfA>RQ?gY4HOF*Z`[8K*h|`9I!{~s.Rw88>N*<(v4P]`xKBE~bF2Js8G7^s73=|fuPpBH8moA'WQqY\$0i}N$P|f?5+;F-P\KV5S\wzlGvF/ey;[gwy|75qNy<4Eo'U]>J4GIZ{Rq>Nc?.r:^q]%D`1=_#|B=w`YmK,}\+qjA*'}xU>J6>oeK7%wb4T:`W+=gI93U|.L/L;3'q-s*#:Kbn3:OtBq1KFO6T0%De6pZEk:8Oz%(5'=5u/LShw)'l<m{[SE(_c'rA?KpjIH?DStYy{v8|n|uJ4z:@UU2B*PaOP6[uf@I|*X/%Pn]9/*ENCzLQ7>%V.{\fal7{>Z@UQJcQ_xuM",
                'R'
            );
        }

        [TestMethod]
        public void TestMethod7()
        {
            AssertExpected(
                @"p<6;>X\gR0w,BKxdY_VAR]SA'&`MrPGw$W,d{{[s!K-HWy&J,4{uY|G{!q?})}!vth_pR*ml+a[HSyk,2Mn@pL+IVyApkTuJ4pX0ZP~jR#w6^F?82l+IoK$I(15g<_4v:m[NOzYYYtKD$<KgkS#fNNbTYz=RS/u{>Isj<tko+<w@zX(}lo*~(s^4Kr;b|0s<xsEFHPdW@;v[0H99<<{w8&rxY!g[Bh#Iu%f0B1KV(>^<e>Q}g5>4t7a&s40+0\XS<}<N:>Hfe\HX27x*H1wVN<vns6x>n{xHR:]wt(-Z/nx63KyjCx/ct8ufp/{!pexs.:$[2?cTV[*f:}1ESyFfVqsp:hpS\Yl'x'4+y2s;Y&ZW(t:9oR?O)FxRo|73?x-I=B_Tjs^N!K3$q^f+\}}k2e6>0_DXr|^+bw?h^BxP8P0t#0es!eebP%ST,pCkd!=X$'sNx{C4s6py}u:GhHKC<)`v|#1+*9~bE&x'S_ibSVjw}E$701v;",
                'G'
            );
        }

        [TestMethod]
        public void TestMethod8()
        {
            AssertExpected(
                @"r~}8VQk&WyoW<A)2rGdqia:VMPkadG=Z*-z/D[3E,iO7;La\5KC'Er2ky27&7TIkCiUH9/(r\ICR&U107Iw.3dv'4uAL?x%4!7x`Zsx76)]9V!b=X&Bi<&pkE$%(;NS6k|G+~xJ^wupxv(S,gLvKK<&&'FNtkxk_=vThabeTOV&IJ8oe0?Pd%cF&nBvMYaD6^q(}(`x:[c8&;J9'+Ix>Tu9U}8Qn_b'<%ZuTShpz3:Y>lxE8Pg-CV}/&`.K]SWW..zQElVV$LcpBxsXlV}Hsi)WwDvKdX0_I(?5xfK9i@@(zcZcMaNI,-7LRnwAe5K6s+$>oG>Y2`!cgU3>=JiyN'c`^NA3GYH09O>>i?e\#X;hfdQ,<)&^n{*A,?NkU]hU!8:.y7\kxs;x5p^Gq4Gj8tr$nxIt}QE(!!?atsF?D\i(u4*OP&xbr5V@fM'M\yE=N3kB,7)q/ZLN1Q9n6{~@sJfZeaePpW^wW!`dg~NjgZ1lgF!wC'6>P",
                'I'
            );
        }

        [TestMethod]
        public void TestMethod9()
        {
            AssertExpected(
                @"]L=)){fPPg9~IR#_2SaebH[i+DCNM_wP*GOc:J[9&|-GB0xGAK>qvCd|?H$KiTbk!'}F?P_<{jo^D`?Tiz!&UHXG*Ym2*G.r1kP;'P8_{ncN0sjCC.)m{O6(.]]>d.K}v74GT*NlR%lJ(_z?p\ATP6bc{C%n|jZue#>6VCBs8BTn%pI8srGL@hg{k!d(GV-sw-}5I%8}Bs<cQ%Qq1z`-x;LM>^_|67B]R>}TXA8u_kl,PV{#4n;Mkm8-r0>1.9Z2M7T]+E]@J$-O-'LR>b<?`_(IF}Y/$m[O-~9aE{W_>.(UC`CVdQrxYQX^nN{|_gyt<4?FzW+1m}%Z]2VppJxr/jfF&}umi?\HRPD,\`%_ZX.mpICC&'-LNmEG/c0a%ZThZPytsNWFV&o6:nAS+>gmHH{T?nq7%n{>|0Xoq\^\E)8cO'OGfa7V2#'t9YDT5A5h;%s\+.\AtX4V'oCmksFY?0paHxFo,{h>7u_\}4zv`&nl/8swZ){!",
                '\0'
            );
        }

        [TestMethod]
        public void TestMethod10()
        {
            AssertExpected(
                "88",
                '\0'
            );
        }

        [TestMethod]
        public void TestMethod11()
        {
            AssertExpected(
                "11554466779988332255",
                '\0'
            );
        }

        [TestMethod]
        public void TestMethod12()
        {
            AssertExpected(
                @"2n%)(`^xRMF9f'>)g!3(W3-OstQ^Fp{NObTlsHb(#Ianx/;x#gy)js:YROCnQ-<,^r90AxJj*&&Iq;=,B;u-W2odqg/93/!<sqY9]{5IrJOH<LJ7ZMi#dt[#1kIZzY`'WTYL[Zd.!-_;MQ6%1gURLeAVyUoP{_Jm_(?[m&.=\guw4H6iy&:SkROUYi#8xk@t.|Pp+#2-O'A_>UhpViZtb`|h@kuAc89=dt7!-|=|BMMxOHeSFgva026r%$VD:qWjg7KZyHA-fSL)KPTgPrL&,`=pFtt16xcFEaJ>qr6Dc|0rD`E-a$OPhmwZ129flHT{U`[j%c:lHf|\%o\\V[,y{+5#1}`dBFvx0%%J/arSbA+`FWiQR=''G;\cD3wpag;Nkvrr]DvZ@nqj>1,#8VC?XUq&2`G74FPb!-fg'dgI:(EhxJY2_t@[tnKe3:Q2JlQeyn!Q1Y>ZCTRMk5RcZAw=#RZUJ;Kg9|UG/J,9n$zoLobIkL~rwObp",
                '2'
            );
        }

        [TestMethod]
        public void TestMethod13()
        {
            AssertExpected(
                "",
                '\0'
            );
        }

        [TestMethod]
        public void TestMethod14()
        {
            AssertExpected(
                @"SYONd>]gxQFCI.@jb=3Wh5xx2GRX*\bdB!en|,FJ-^U:4#h<ffb|KzVQj3~27\Zi75R#LZtJs3%-;0Sy+gH<sk$[UL_as\qH1WR/v|6$Z.1xTa{uncxJwOx})a3^(+3>T}SqhU#9U3>A?ypMr`u)~uDZ,H^Y(y'l~+$i|+@PKI$F}Hj!5fT?`1*{X#s8*LA','t+8e0VG4XlBic!QH8V18_Ns9hhZDqW'zJGE?9.X5Fy&&p+0folF~7A*5k2)<n?,a9edP[cMuSCMTp/hE6A)Y0o=0P*l-{Y'U$w*y2?KRxN9:Y\1O?\6:B/rRDS$!B-aX>:8MP*u0plQZV><Qga:nHk~(dtzZ'=R<j/XkeqG6V\^]H,@!_{xO<FLcm$P=qKqq:uwTfx}}qF1kR\hsoG/:;U.He/0@h%+Xx,U5^6/K-N>TT-){*X4@r:+Ho5p{^Tz]DDX}Hm`DIxb*?:jbjLM}ry*F8:@%2S8#.*95VB^*-?A1O]!&Er",
                'O'
            );
        }

        [TestMethod]
        public void TestMethod15()
        {
            AssertExpected(
                @"qX|\Wsuv/e1&kb@{u_%Mw5%C87,>@rRU{}%Yz6m`]R@u`kcP+h5U(({R3=@_{7~r3FVDRWpgk~5eU55Mk7GIuw?2RxH4I$:{Wt6KCT,sTGv7JCuJ.b*:wptx><#j_gW{p{gMJyIN(u=JKg6}+;.5}*1t$%@M]Jc@qen21KjqPT*BX/a/E?4e6x'1'r@3uiR:t2y<LXiR//~h[xhnmFcJ\$x;[Am>YBv5D3_}?+Zx|JtJE*p5`i}1)HF\Ecj@t`c*lIpK!Y^uR~'[McT*<~j.Mdx]~}ZO(?\4S3^F|Kh5n)asDZQHf[]X)[eT'T:_6GX1QDq|szsD-H4ocWJ4+0!gd=4.dpN!Q`mR);$~9*zCJpibFrMq%u~~H?9>IoWO'',OuX{JUY=OWj]eTCYXDoiblbv/$V!,'BT0SQ-9RIt\;J;\HF%zuw(|iEoGI7SI?@\,?`Br<k=;,<w=U['D;GrIS~mT,N8I;A&m%YO!1)_NQTt}Y{/aT&zxK",
                'q'
            );
        }

        [TestMethod]
        public void TestMethod16()
        {
            AssertExpected(
                @"V(O!jYLi&o^>,9Gv8LN8yAvY6QBbzxxYjN_iDd/-[UK~1Ua2+s.1,QUav^_D9FagRnjA8GPHxS>'.EZ<?+yQ)9`:*+k*wN*};$7Ng/HBoRx!!]V?'k{`P`AJIp3+ZE4=k221l,3Nnd}1#KN%ys^g1n75e/ZxZ8qN7nJP{&rL0#SUnyv:F`QodSx5x]FVE[~g?cW0?T!pV0=A/v/lgb,iEC``*)0dz~86I<prn{5P>L*6mh(X#f7~iVIRx;.%x`DHdxJE(hoxJYu]1XQX0-^?|*z2xK_gSnFYuA8N_e>DR;_p1bb[Ug2>%e}~>3m>Fe}4z28JexMKm^F'n=TA?.m=g]a5KZr^jBDbZk[Aph[7no:_xCM997E!5}z'xD?WekzRg2|8_iS`ETe95UZ2))#XL$yVPj7#vYFlQVdj4<RZVc&24r\_/+A34yN_x:@i.*#PnZR{KG)n7DN*JK1W-x]fA=hEIV!{hrT-Q;P=q~Z68^lnRrNLpd'3o",
                'V'
            );
        }

        [TestMethod]
        public void TestMethod17()
        {
            AssertExpected(
                @"'-GhFht/\RfaCc0@|x>:%4x4*eE-d[H<YTht1o{GC\RIc0oDBmj>);4y=LDZQ@*ACeL8>+Yd0=|^LUne4;?|@L}+uN|h.IjD'iP@gv-:}91ni:\1sPq6B\3]2DoMM<%N0pW|Zjdvr_6H@4gStL4N[@L!h,lv7}D2-veQeGt0jI+(W<A59#hU%*%%$xA:m\)3pR5uC.YFMz`Pbg/<DuYiH)qo'eVC%7qoh.JpSX_Gi5[zbJsW3RX$?8XHqqEF`oMNyLaB6]9ZFM<JaULat+8/wB4}?6$*@uZxCCkeK`[-<?1jgMw'Czi}-H4@}+E^%_?]dS/imMFkm.\ns@v4xQ^'Xxx.VnJ'\5HmXN#t2|6x9oP)]+#lV~_M5t+7UOQ{q%yT+`8&CW8nlQmdW.GWcG..I6I5d0=&x+sEfT.aW+}->E?*zCJ^>L0.S^vv}GTT(;(n>m&bc^bkY$xxm1c3)!,JU?Sb&#\.bnc[w?huH\=WD9N7BWLFKQmTBj!E+Z,cSpxrRN|r?)3Kx?o&H6]Zo1c7:Q)eGQ.-FhX6*yCJ.%$2rTWh`.KcP>~[7HPx#PD]Jch9>Y@OZe]j:MB|]L\fSlJHkgTFrvMxd+ou=7o4{EYasMTm4('u(#\|pGbC`1`Z[=u#o<[.ae{hMF2{}OX}ku9L3NY|#QeGkx(FZx1ETS60*nL}E0BxjMzC9AhtBIL8#i^f;5F/WaffuDOJSU%U`.3PhTijaN:-2wx6&DGjfbAT2nO@XzQivjn'x_Y%A9l*fH^znInPx8Oibzm?pz@I'qBh(weH5zRr8Uv)=GlKZow5KZL~,j)Wgg5;0_2&;O'.dD{zt5P!WUOqlW=A1;RQz0_N@Lm_Q-xP)Ix!ZXiU=H'Vy?5TB`#.z@~xWrj=:{nxJ;H?BF'XNlN|PUZC4Dg~K/gZ9yniqL1+r[C/v}sKCviO==W`#`p/u!XRZ'7rWb-p:>g3s^J$K&O%](xc_Z,a69v}zyHq]ecnDY!g2x:V:um!l:H,Ok!{('hL:6J=6|rs+`)$/xD4G!{JpJ7zj'!_^IcTHeL%Y;Km,Eh+q()'>y*/#+&wB8f^fO&Oove68;DxcHo|D^+W}:R9r&zT\,oaX$hG1<fuo,b,Mm4xuuM1?m(~1,DDc6|cXt[e>i0wxqO*m}?+IprN2$mJ+wR'cf6{w-qq6*TNo?GI2VcfsHa0]#>K)P{VFe'i/jA>l1ncE2\xNYlE_N\XIL{7G\EK:xtPM=>.$T!i*0RaNoyca[;<mG8`;tV-HFhOth4Zc#S[-=c+aIz%cv86Q2\}lD9efQMk=[}50=\F+$F~7^{uBv2Tc3CJ?!dRj@Va$4}bC?N_E4+#d''!$<{qx4J.vhNxR_N[L\C*{F,..a[R5;F<`k5g1kzXMTGAj+Vy-.}^3ZKf}sYIsBcNOx}i-@5i4lr3-!^[.cS,hMH\l&1Vl9clY\Kit:qy_Y@%Z^*WZj#;9l2=Z#iG'G_gyn#J~A-Q7CG\>72nKc<{AIpSI_I$7mFr;`b3c|dVX_c$>(CW*CZ|d<M(o>avoL,bmAYHZTSSn%f=v-=*w58^B4%w,{:v`~LR@2jL06UK}m6,em2izx[&;.sOEc_3#16K#=+M7:^x`x85WrpprJ@QHxbsJx$z.3a,t$5f^s_;PlQ3}ER/Z$8/BE<h%5I:qd#Ixu7#AFGG7|WhslK!ToSZto}aw{h;x]oti}Oxwd.8:~}q8`YW}sg#0V*uHx,Hw[.F}d6E9+y\uJ=^!<1|V5qX*<O?[lc=<cg<vJJn9!et;tQ=_qM\9@|m,#;6K@!Gk=[7IN([5+_!$&]4yY&Qq5(mOOzT/.9]WHtr6VJ#0qH9V_OT)vI(S#Ga2O#*xE.)gpYgxbwTj_CzZkLUnui%6/dcv[B!]-HqZ`c2}=6zW&$0]1mT?8wc9-:-6fd>x[U#.rp*`h=~GB~eORmZhQzbxB(qHh69,xr@:O~sy`/H6'jI[<jz9UUQv}_MzSRA^l;wW-AsP+bhG\Eus@[V.,frZA4s?b_ZB&*1_WZ!4agg*/czB&NHV]%=%}ydI:7DTC<Db'z3*QEVw-7{s0kaLpumZW)vO%=MP[s.NGUON&/sJO<=m{ZP2W)WMQ]m60cMZ<-)8d?;JA1+'V$bAVP88=q<{H{[T[-7z}--qbJE&F6v/t;\~#OFFfnH_e@DxEz:yy*)^*B!<ke2@(C0YJg>yJ\O0,t_~F<y+g'd0=+[`0pp`^;~Oz:A3>e;&8YnR@c?Pm1%>8Cqh!.Wxf.*3tUb$?6&>9][SH[%8-Vh)/$iLj&vx&Q(~!CP9o|*#30xlt2>6*>&/q@)]dpwEdBr,+Huxl'e}1;4/?RrqQK}zY>~4?Q|Wg&8,WkjPF2k$0Jz[{I3afu<cC-/4CAeEp5Bd_Yiy@[3#75(bW`m0t{\>tsP%X)bt&7o>fK$)%NX+Y);f;@.xu(YmG{rXrQ0aIh<cB{lx!w4`2jaL6t9_R|&Ejx'D7']0EKu@LQI4h^|o,KO?y\L1WV-X<F[E62lyZ/#mR1qK;L+\5hue\Q,T}G6*Gh+o[YJhFh2d>d|=U3Duj90]{)7@[ZR9?lxx;K?AeH%~ux2r#1Eg~iGPu!#ID>:HOs$f2{M;q5/=BH,N(DUCgF@Ynk_{n2-01Ngv0ztFPL=JaLi5S2EPyWi@gI~kH,S,^vg)^@0Wn^!<P'^<i.Y-[>T9TipeC'p'A[OVIJy*Od.Y+g`!\xi;DSZL0O+X<4dFl_wAx?j*;0^a|CeB=6hPZS%8lM'\{E'o:/@wm+w5f&&'[~c^)4}GYXUJ22IH+u-Mj[~p6YC'J0Fb\gnSmq<hd5#zLxFo<7Z3pzWHMI~Iy~x]R;A5}3b)jHuWe0E@xM5R,7K;|p5XdFNyZSMg\xC2}Ud~tWu@/IJQ;/^TK*+a~@6X:\*?^(Ga!+A@.MczhA/(>^Q^Pw'p/F75IY#x>zB%df_#+#[Pz<dW>QDt#!@Fz@OCr5=*;.Y'4%@u3XrOUnK7M)Zc)dl\nVw^81Q|6W%W:Lx^uoUZp@N*xjg`K&(a#0WRv!|%s#bOH|qoitN+*CkR|'_'J}WLmmi-`3!?kUYNO+bl!;;#>\2]eKI]CwDNo7+%/*u3XcF`MW3*F1Yx[7yE6y~GGHlN}><'-H1!Z\U[Ga@U<CZZ22x8:PU+r_GPk?zx(gYxO%>sLX^dXpL-z$jYI$b!+.{^js./LPG|Un$frvPgT:iftATzX6r|Vr~BWUT$|cU}S>+F&v!Rok@g<;@>B,y!p?WaixW\rr60(({b6L8Pqk*Z9P>qt'RxC*5ccd%o+p]@rFS0KutLKxc{Tgf|$!{dxE~4xAz(O>uS3aezR,[~i4kI5:R0uaI]}t'6GknQ(BJ)kDFxdnaiw/B/VG9j]4Ixrlvy'^7!~{+t4H5}oio8+QHBPxfjh\#H{g`>|6v6s_vNMza)@AJQf7KSxm+>yPA~g!5WdHRclgg5}&rq9-I{$(p_uSt^`[1\YFKZk#47Oy]41s<Qa&:tpkv8bWlt*Q;WShQ&mVMHIm?O_HKL(=KY8^]q]B=W6~;(ew'P/fFnqThI>zXb|s|_%Bq)Mx=yG9<7,<xk$pW\fbs)xFx+:Bx?IUA3kP]L8IZU$|X~<yUJugv'T95pk,dr8FyL&#Od'xrsEfmY'Q#KsJDa5.ZlTx3PQZ;W-C%P'F)_:y]HIWVdw!8d~,If).<h}N3]$DL4%Q/ZsR,b}5FV/GnXzMSccUC_cD7~YbVGyKd?J5dg_>xEhP4Jpdj,3s'%_0;MOY(rh<2,K+FZ_MdoX|b%I:UP_S~:0@do9%=`.<)A>gwgjpj<NcA(-zM&BzdElC:VmYywxkkBi\n8V4~;['WW/[+dqc$S'U,zw*kxgT$KM:uG%)Du&YT.g2=,V:QQx/,Ldi-B,O.Lj|UqboBSGdy3;f6Is*OC?-qZ)[:FUK<+X?/jul0$blqaGl:E>RmcI|S?&T/A3,CG]3U?2WWx<AW4WjzTSXbw~5RKh7#37];_ADroG{ha$;x$!qJc8w%rh\Ov<$!)NC'g]Gx*1XsX!Hmc,Rci<#-;E'dzdycgSI/8`XAA:UF5-$}y>cxLnt[iU77j8j>:xP[eAw9<]8x8'GVdTg[gUT).6*3GpI:@l$dDu,O411[1&`qY}w/(GhKN!-.~Ce)Pib[cTE<P;H>*x2[D6%xbp)0KV_S-i\L4@^>?`Kr;dQMv0k;t*)Ka&%hz}e+y$n-(1vXDN2Z::iQ*e2\O4<4PHlj'Cmlv-Kr\E{-o3&kA?Kk`cE>'oplMz7SkIr**#<C3i4#0,un'w~Jhn&k8+3^7?0sO;OGKJ%4KYDP3sO\2#1T.tvr{0_7n8CsB{MSQ4Yn.q]o|v*]qrT;)W>HdAe}+rV!zjH.qk{BXucn9p/v',n+GC4qxr!fo)x{MQ\U9-$^3>z1Dn}p:stexy?O92W(ILtS34X{hfh;*]Ux80UAmi%h9hT!\yx{aLt[gkK'bOVI,Ag9Lx?>Efai;d;<kB^?4rV},/c)1y3gZ#x[BrlN\K8SYiL\!x5NXSO^lN6l6%XR<w<mnMqz9Tc=xV=0^O7^)'4B\icJ$|+}SI931L_,B~a[y+ax5}<4GXOtL62`RSbvH<k~t<l3&1oe#SB.:q]La+~AT8C:mxR,x7MCD>tyN!]N5-}s]!wc/MXRHNKBz)+0uJbz\`njwq#khYy2zbgG,TZu*+6p;xjPPX3;Zk/fEzUng6f7R76rjNK&BxzFkM#IXLle`+[8I=}:234lPmFJ@UPj]:?[=DUP>+[NTAJF%bto8V+%kR^g)NH/.va\,Olo^tvg'R<@'dV9GISLO{%{4_B8$@wP.~HM|'89ey]Uf9#SvshrH;!_xEgcG24bR{ITT9c?pH{&v_qS8gG<MzVIA&c_3dQm^JRz7R)Q=huW!T>7tuVZrJ0GCEaaE%#PICY@v1HFq04Aa5AfgY%(N'YCNG9H/$bW8vyTjx1Pg4y1DP^huJ+uuE~!geKZU76Qzp4TN}3gH$rDu>PQeYo<oncLG*e>lh>Py|xqdJ[P>S:Ht~Wl",
                '''
            );
        }

        [TestMethod]
        public void TestMethod18()
        {
            AssertExpected(
                @"Zc18r$[N_w4-Gu}(zduoa>G8_0C}.qrk~AU.K@g:o:<uq_GrPn$`6Gakh9$+rxx}?HP~}Dm7D+OAljT|ir]?n6k{2!/5Z$on>hq.RhIR)H;mM+w<'Jm<}]]7VC|GX]EOaS/GAH/dz}OL,k4<*N)sFq~B`cZ0qiA$KX0i5d7^WgwjoMW((k-jx)^B6]7k8@w#N=J;'Fu'S}x/AdrC&VN2(H5UleVT0g{Q*i/V^./7iKit}1PVf_3DdG_gY@Vk&ETirxd2mrtXw%fO'5kRa9j&2z(wxUsoX5gkq\PGAzpdxg@v~~6s{Aokkl`6OwgX/%~7Sxzi,lVD{';xJqnxqxn@qcEv3BjrBCq6tEQ?Ch@Ez%,0k%$y\${2Wxr0q.MRb+yQ@j{-{AcC:e*rSou:<0`E-f{TkmxxUe#%U#P_=[OC6!<oks1}/(1R+y,Z(z?U`*%3fg//:x(HJ-7M@jTn7TC27zvL'!=rB9-#>[~?BTm?'[(B|yh$Bs'-*.r13To*}:0_wQFVR#1zE^xy_X{jvHO`%yrmq$njoD0ttYYM3*[W(H_lV9g:n;~Bn+IeMHs0Y9XQzNN(:oD{?{grzqdG8^~X5:Ex85(9NU9D!\T)Y5K5rSXboX^)zK]p)kpi_dhrBK<KPMz#ZL6@^L;0z{;'^|C,r1Ch+LP?,axr+o8]Fu,hb'9ZqHKpdMSumCj)Wki[e2B(p~+%wxx1_Jo8_<S|q|[H&1xsbn1y\1JKhMmZL;U_jzW#^:)GB9n,?xLT^_Iyka~?2_zS69N_>_=7dFrI)E9K:qXja\\1B1&C)(%LGxMv5kTEAOM-&nb=Ne#E8f:PpZ=4@mQ9gHW#.phy<P4WhnOQ|9$4!DR.rD%2@nGTz:rUn_GX_BA^/#)4xtb@^^xUc*K)N:U;`[p);[EKf#AgquKedNxgyP^RIol$dY>N@\#`a+w)KEw#7gO2`%+{}J+@jHtYht8/AQ?x{m/Ct:KiC*Q2$w?#MIsWjvACaV.Sjap'DTB*e28!:|nFo/2/HMX3J<rTK8e_@7a=yZq>0AdU(|l@h:%0i*tXL=y]V^cqi(+x|}8J,yD2Lum&h|]y@[xfLqzt<:ztS?nc|4+wUa@w{+W^dn6yXm+w>:*J3Iwb_%xa2wJ@#*pJF[uPu{'Ka]KnTr2!6rN>gq>i3R2tek2,{4kef)pXm'z]mfUzORaW0%Pr+P1KNT8jT@n{v,/,<^O@~cq{G.dV1jbXK?>88GcTtBm$k8N|1^[t&a&!TJ@dg++lbr4@$kPiypV|L>zx%C]*NfzgeI~`,'1rDv[[o1LM]F)5ioFuh^p/5A|${1lIB<|&s2<qDvFxo7+MkxEyvAStQ8o5(w1IHK(VS4^PhQx1mgOZD^@k^j*cgVQY~K;NO44cX6CCyF%B,C24k6Hx05>vZN#s}liyny5hPKYRMgs4}j|oP_x@Q7G)pBYAkQm2{)4?NF4QL4p4]Qt2-;1v6M[/P5PMJzb1UI`Sh3Fr-FJ=L?Rx,=B/:DVafjxD=mIK]I$QSm^kQn5k9d'?k;O'WL;r:|-TXO-2>H*%.qLgwxb1&YIi@%hn6'.8]?31@|!/0BD?|V%\?LO/GKp_6$Pk)Cm.~4NoBMR8a'xc]x'.c-(lv<u.|0lJ'w4_9m'XOGc&^<.e]!1t]pKn*#H=4#:u4k1G)}gx4:YKm[)'@huZ/eodZ{x$O-.;!,@&tH1~n#g@2!g3D@dj!sv,|mg\<AHWeUh8e#H*@{/]cwnh%BS\vv6<#S/iF,qm(&tU|`]u?WCd2N1?BnM.cp?RSl(LI:fsK[vcfq+e_Vb1\]U'Zw0g66Ex;$uj7w2xc9H7(!,ea1FBX_%RDY?`[n\|kQ'u9.0]@!;et'@@pqxu#P-=bbE).f14zgfQ-0K;HBZm4$/{o(?<jMZEnyO@-_I;vEZNg99K](Za6%im|XMpKDv{7'R|=_&5=EdsghLguGQ^w?o_f(X+J)=[{oI^JJO>aw5_+xsXtj92TD/wZMFjgefKt=@E{cT/'|x3S`+7<5Y|&3_NED)y^]5gb2AXfD7r:@BFO^*Psh,px<\5v>?rn\26fQ|+\]w]Tv''+[eAn*$y<)RV9#q;v/m2KMKvkGa1cz7=_fm`5')mj^,:\~y,1?8igLMLT972rW9KZs9x``.t.vt=~K*<VA7r`,3wM'=25w$}mS};!W4*AGO64f\x1>TUjEZ'N^dZvT4zpSqCB9Qi~14nG-[?RXx1\ibFEwKy5jwTTN2lQ~,S~~ec=B)Py=+y!!@ojM}}E|o#7i`c'lmrko7_'40BiLKV9oxxGiBT`~fcK0S[Trh:]HZL^=i+udtq:0#r<LL(QzW8teh-{~Lp{X!w'IDzOL2Ip{JBKg/(UTuzyD]Uay6#S/ED!}c'2[oh^iQN7@DH*D>~U`e#9PdQ;`6ydrYo&|SM^Z;fmY{uaB2z1<s8=CV-J`;&f4$~n4kD@7Yk.,q*I?HpP[Aq8`&Ml,k:,A@hrzojq?:neMrZ{5~Jeb\K<L*ZPpZN6G7lv]p4X&&},QHSq}c+RS:f=bA<t|80\([w#!\jt2K{&sE;c=X:>LxIVc-=CIUp8MgqAsX}Nil(NWm=[U\)`;)}36kddC8o!CW?z3C]f6@z7G5N6l{\/Uk7):4J1GJ`TPK4e16pemk$&jxv^3M!!/?}suZ(wmvM|B!jy!KHYB+,XwTOEB(|DU^PA9ZZ?{)mvSBSnFq@gCsImTMie<[p_:=b#!bwS4~beo[mra,E*b6Zo/;mEE4kcOjFKK+CM:O}fFyU@8vNC?og=g?sgFe:sQOG)Mdf(-I3Jf(}_{K.^SMz1snpfA.vWu1@Z5Ew\m^X3/[;p2IJ<B2V4:[vNMaOIn8aa1^(K,{Y&wl^:`A&S@;wUctGEAXTn[k`kqx,b7VFVkl*C?F4j$77>y^nO)*N?`-\dWjw:ZM}+t0Ux-bk`zZ6Rx.v6tp;x5lP&nNU)HutglCf5'KhE20Gyf:t_C)^<gn}Vs-in87d:FfS@n1OMy-UPf'q,&*88Wy]|J<'n_K~74$@P7Gzu]=iN[/wnl7bM}~sT<;;~.IP\Ocn=jDtt&i$c1sO:)9Zj-zOJD_`rcZ!58zMbiA.IN&)r5h/GAP!yI2m9AImy{W_.z-J4Ry-,YOJK{b&:5B9>1!vluxBL[9'jpP4UaXsXi*=5n,hQlpd33|k4%),v.x9mF%w#)*\&'XBotFy8]%VyO`DYYq@tj3\s?4e]@f&yxKHxpDxCF5p^0_oYk<PFu%Px4`)}C|Y7i%A$L^^5uT.FE7iMuVhA0fe]RZ\sO1Qt`lfY[M``@7;).+:y,9N>x~.a{#$;oNN0/x4[r.p/Q.zqtzSI~EenKMW~B#@bdZwks,0`9g-mH[g4^pW0vo$,F.5GlC$@Foggu@=bT%tmI>`i&V_x{C+;1c;{:u7S2a98p(U)}Q3<#_uYE(}b2@4vTPRlM<)pYWNi^%8U3NxEWs`@+MH7C79AB|f=jZrAh-fYcFMn-cV5d9+x._IR^J`H_r!SrR9BgD<X(hhB09D_W>WW.=FR!10lf}G((i@K<xqSvQO&<XDVtp<`DpSp%v?X)t`@5uVmV0aWiyo|\/J'-0,g'XCs({Qc^!--cuR.QIm}HT}FX84\4o`sLuF~Uq]\pkHAT<XEsBguC#[7@;c~&kw\TOy=bmRH=PX5-R;LEdgzMDtDIT]*cDROzxCTI@x=(LPV7}Bh~AWYy+N=xGz.#zg5K)Vzzpm'2I%+Y96zg}x4sxr4Dc`v/Yg_mk0<~]iH+g!06&P9qDmdKU%tD.(6oJlW0`T1^$o!Jgm|T#*d%)caIc-WeFG5[JRLQ@n--L1UEANs>nK<*@P*Kp5*I2g<r~e(\.j2!&t.c<wW\Q:KjpndTHtun=+*UZ^pcpUQY0K9^ckxeQ8Y6sov.l4=eWy+)@UZI[+,-M84j*vzEjO3o][MRMhF6aW4>TZ?hQ3qL&R6m1hrMZmdJ58$!/zvF'Sx/*^Z%cfDO[Gq=XQ:pXe<^hBZTW&koa:C|vv8yo<%]@'b6cCrve8~nD[l^gE@9N,(Z6IuaYXjaE.S#-GY%{I8]u@HffovBuP@xu..j3D\;!ojHB}O_hO!i>%{[J/;5obnsM!/}e3h_S)@O-?|+W<W*T+>@qI0D)0lBjgB2[Hcx'\Cu|:1QLZ.ngLNyo`rV7J##8%P)>=U1c}a2ZzMR3.lNoA!3u!EX2wkaTyB=mGP/_0*}YxN<o7OD#wCuf}q*yh-nX?/`o+s%p1p{%.&dtv*[(gIrMi5,\>wjYPW(R^{r[P}Hm.6hCx4rPKJw/$2*%,,(fAO-n|;A+ww3Vvl(E}'dpE?XDI(]'d~t5,d?5F/eM*tI7+v9L`L[G|I$TyT[$.&XG+\Rz`w-g7A^8n&0B~|-4L-FI2<VTx%5dXx23{CRzNPWNag\Jy*~kQJ4w@-h5E56w6$Mm;wP5YRKJ+/>|l_R|HrB.D&mwe)9]?%xX@|I=>#'B.=[_S->rPYSP'cE)E<s:xfpIOcKf5'8\\4G>v;wvvFdox~D-?(O4R~rW]CDE#S_`(8dst#3E5`[k7{A1}/vbn:&7WF=<?%{`E'Jysqc2Gz36jI8h_I8|f5-Em`F*8A3a4ZS_Vxrq_)z(s?igj.GlKq(I5dy==q<R9ygB:_NWczri_Lkvq-I[5puDCbS+K8]5}dT'@{j?u)bHhG:MO'!'<!DqFVm1;q>wC^^xi.V.^=WOlwv@X@>(D#\p'D&Z.!45*YDNZV](md^r4W%'6:E1WxF%p1H)BSoVzupH1:b5YRvm3%Vn4(W1j`)bh-VYR/[/7`h/C'Uj3^>vtSTU=-Si]v^18iBHs>[Ck/>Lh+\o1<JHRG1|rH~hb@:'B6>cr)'R'5:gba,]C}-f%OLbT7+vnN;4YQ-:@n|/nns(>j?Ys/CJ`rCwLzQtmR-ye=oJ`PVl1&~2ph?Ox%H!5ORYRrbExFn]ct90yIx?EPS7*>:%AZ)7j8qD-Kvg@}86._9j!Y%sCocuMZTd-CckgV_B;/C(e7h?m%B#L~uHp]V5EOI}:",
                'Z'
            );
        }

        [TestMethod]
        public void TestMethod19()
        {
            AssertExpected(
                @"y4s?`cvl;_P*ddVlqWb5`X}~]-Ucr.L~b|yuA59G_s.Eah_=GS')jk>pEUy9DnHmY`@ZY+sx]PJxxp^%p&y`p0}/\nPuH-ARC]_,(CD?Bil;TS\qp0-~]W7a$LH2&tQ6J57$38l!>SE5~Xo'dg[iyzD1EA~pP2(m-,?)hdgo!A~+Px=<!*5_(6q~/&zs$zNPtVtKyVp<xL^a53hHxyc\(RW3a<!FEJGR#K@Srb<:qU&ZjEt-7N{H2,$jJ}^RAu,kj]bp#q>8*Un6F;\&m=rQkz[;wC}7YzCa?]5E^L4.YsW^m[LH|yIY7;(Gf41NUJG4A3!uqin3;8OUFqXMMtt\e&wE18.K0xs}PHTpA+KCAsnbt3.-^`0Wq)9DSxz{7Y]&+3b\/#zp`JIy>g<b~jF*O~'QLmIU:r\0pixt>R~ObE:UTj?Q=VIIHxQ-.iEkN=x0i^{bsTSKRZp@-SB^/Dzi&J\pBnQpMyxa&k$~;PgNA98jF6,g%Y&#C`)o%IlTMuQA3&&6J[#L{DU1)v^*xDagIx'Ai:3fAx3.Usn|_$:;u%PY\6cfPYiJ:Io]GwC.6!_SbGH^3-V=nW!]4xa4O&HtxCY~JSGeDbxP{|jEx2m0&XTt{I%B56bZmf6cM?#Vzu'%o'5o#`cqn=3:am6rFCDc?C@m$H=>YtXbjb>-lVZquixvxg9MbXhz8hX9x[8eVThHh*>KXXS_7OV$|=li?<GE4L9ykV,$6ybgLqT!^E{V0QVP+(G?>Ta0,&JDb$\tL:9N/2NgHT~'WK/I-n;22OBdgaSG<xG=umK?sbC50/Rbf$Uq=5\{+a<7N5IF8ZE<H)eQ(Z1p~*X2//hzUpwZB<{pn7]Nu]^$r,Xl(?3h@-Oe,=j#DfX6(Y;eZ3HpPK?jFkop+k^`2xsE+4nsunQOB3DzPN@---n6&xb=O5Qo1w'NK\AgvJ)=@q}1hSPNNZ:AYoK~wq`c{07I/w:?IEVk%a2pQY4ModP!~q,NY8L`(@.g_rWn82@r':k}<Kk$.s-(!e'\'^2Xz=l,M/HEpDhQ-P]Bt5WT5O6BIC~Fibg>={LYD6Sa?TLi>'V~K,mwqsuFblX2ZEM#[S|S3?4qtO[N_69GggrblJn~B;w@_#ZH9x]$cHwOw7MQX(a7b^UVJCD@e/b|Bb#OFlvZK@|W/xM1$Wx5Zt#28/={G~LYDt{2igAfkWOgh1HY`JR4hxpj38(:~IqZax=4SiTX`twrq;VBP@8A%0=Bro4_yB06xsE71+d=15rK_*3V6axsa0A(*Xw|^TKxV8Mz-zpbLf|!ASXrjOz>Jx\0-D^[2%WJ#CtQ!BF!Q%^\y|[G,~JDV-hgY;dJ$AV0@<}(tyZuYf7{NxS#IVv5JI~_mzI7d~+)I\/mU_`3%wt|GC:JUof0l7EUv5I0VTJ&f$sCJ,}}iud_4s/UUPY.Q'$5:$*tv)q2Bd504srBH5>bfv1>a01\Zslx;n_j\Z9@H/}-FhX(i`'{3(7n3yti\H&=hfR7;bV><WDlDi&l|WDs?:@(z8Hx*f.sMf5uLb8Fzq1in6|,,-?[88W}YSVbe}hZ18'~>`p,Bjp?c)<3%y>oIt<SwQf7N.NEbMdzN+#r4B7~w<~SL|cBhz{65,B@yh%65Q`m_nl!J!EA~G*S&hg0lk~-OYeX%c+77s9w=V;_udc<EPnXRAP_1;<p3ft^OJz)c)G*mo`viaj=icr)Yess!nFZiqA~((heWH.SAd.uL&2kQow}G[5OOE]Yut4Xu^0q{6LvWA|YD3]RLmkY5J+Q#*S8Wj81L\C6bsz&@z2}/MTlF3s@\6ZUI}wNduFbO!g~./DBgs<H;aUh/gosw[7M=>%,+u{>#1~NzeHhquz_b{Mnl*{}*Y@$7Ttwjr?v;C20drYh7Yw8ox%c$_W]YRN6?L%VAozu1}%0N*$|&UmGTER?cow#{b+_ypd\~x\A~YFxx{nd=duYK(m`8f^du'xnIjjp1PnOW{y]Ve8cB@/`+/35$tKD~j}G0qvooh7FM?8XD2TT^Y]f9`3lk[/ksb-ds59G@vQ3O2zM>qKWv-<s=V@L8+`>^nms#cJW1Q')0y#e+Gp>HQLr8vD0cL;0k}e|g7H_aDW]ejjl4#EE=rH<xVrz%n</[P7GIJ7$F.N<#fOrn?{48$|JN\_5jG/rAiB=.s=lvCen{VJ|@>V~8m/}v}2A,*,*%y?+Eb*^&??P[u:`}X~nZD7>?9eP`cs9u^X#Z*n0W;GLN<y82c%A&);#Cq7=$]FLyb2rZ-u?d)SrBbU7EXwXw>y#e,M`.lfnF0@yw5x1h9D#2-&3^2Wko|*YG\YeZowlzG(#jzD|EwUKM`0iLC4l0D)`,{b1d@3Ym]@CKc^QLCMR'5JA:5}Wt469;N1r3&m/$G4r3xv<3,DK00M:5:''[6_kmap5\L~J!tzQq?awd%!(DQ1-+ts#{#sJv}zPxw[Drc_R/%B.c@F_6TV%h|bHT]E9e*x)$el^?*9;xVa;~:-hK.hg*9SR^1apfF9lYDoK#Sn%7|blYx[hvI'wJ,v+)l%hl5bCk&nNWlN)(Rv$$,OAmAl_C0gQ;U<FI~!#Xb>wiGpYwGe?Hx*{8QTmUN2w+MEVr8[uYFH71JZ#^~l1<bYx`,C(|oWtL(oa^aALgNM=Jw+],Y~u<b9eysyl;_(TR<W*l@|K3M`yZe8Xw_D5\&xmwdmIr>cW5)JEvfcx~c92/XNjMvceO$I%PjhU-6Gw3/u+nrY?rJ_F`M3QG]_/E@B{x_!l1lqD;ScaEY<uDBR%i`h?pa)'4N@<!1E)i9kSxYfzZ*0-hgH8Zi`honhxlU|Mxt1Cc{Xi$?L^v5YkV*R+@`g&{UYx2z>1#+n^c-(<%d*(:\z!tu5%cKs)Sx{z3#>2!RoB<Q2ao/xa_;ec7W([x`I4r%m^lkSV~IvXTTBP=l+y-Xp209pljW'[(#s!n;bC8-0SjW}T}H:KToQtM-63r1[J9>_}h8x}@kIS#U&@Fi2xB*V5T>yo{JC{pyf)s=YX|3Nsf%|1/4x[mpN|TP$MUcwz'0;6VAh,6O$(_X'^K[B3&YLN5=S<*jr-|\VsD[FtNDj654e71JhlY}]^wo9a@#Z}0V6QH}?Sv[%0IU5kY}}4}6TAv*cK#pI$2X+`V7C(IGcV#ISOU)u-`:Q3q#lv.m_~3vl%21`?53f}bbb/Wm)@qy~VINH'N'T5JTeyziJD;dz\FWC'ui6qoHXE.`2kOlaGRe!`7(B[YGdjFEUN<>dcN45=c-{q#p+A&{N7/eHEl2}O!h<SGWX4Z^NNf)X.,N(06SU9M*xYwpe+yM?kP{B@fySB:0m[vF?_Ql@gRU07pJ{.bTh[Jh#O[a>{RP*E!!Y!:1'(/?v?s&N(4E]RF]n!4RF#p[+&<BLSk0WsM8G?mxDB(]$5j~`4I^<w,I3jPagJ/E=cEugVE8@lX$VcbWQa;M=\fs8CKKg}qS%_{is9|['`XWHWui~op.ZxTecC<5z)@UF%@4Mcp/96_$[8:!AsA8diPHlcX2tQ1IA@H`g9g:-)M2ue',6Z36EW?+~\6ngqlZniNtCn)Hu(p1^nkLHnG?S4FX0QQI`[raB#c>Y*?ZAK=<sk5IM&BQn:sz/3o8et/oA5cw*o>WXOVHG]w%\DR3H/3K~V09H8WZ241[`Kx9ojj~2[$A&G4~,YP/PXB{_aw85pHjN%00&82xJqtS#DQ0M[F8DwZd70rCkMx>q>[5e=+^|*Eu|7~8T$.B!clA-Od,Vs]}AMXG$;xTnN;o;U!c3yrUOWf+G[+_vHz*%~ahRX%jlj;;).5_<vw:M$=_0tJpY0A{5Y{JA;*!Uh~nY9`UM#0'Z~&lat(^O!^:>D#/$T?t4SwUfO%W_9[Rb47Vig_Z)|RKyF~}2-,IUfBfq?+.x[27Hh>r9@uVG~.~dYD{#6svG_</dbd/](Mbq7WH:>F9w,]-<(q>SJ^Tuf3{y>v;B1iZuC92w/5?teCMKJQ*ZYsa')NaFo#6M5#d0l#0LT5HqS~,vj)KBN'c{1KC%rd*t0;PlxAQ!H<0]C**tWK%f}x=+?vF#CEE[@Ck/!Czn@l+Dq?n;*leoCA18?drl1j}F@?cS]53r~V}J=Vb#<K:0V:nZLTb@[TQ0h,.~<.)6EzgGbOpda>:IQ7Ts#>2YbL8gZI%]U_8'Z|.8>#~K2gi4~|>xJ%xaKqOzjZ<d#44E#>dPdFp#H02A8}A5@|V(\,n&IB.?#iK<+d6T*S%F)-T!!)0t`qyXTw`mbNm97Pl?xSR]Wc9J=j#t%@%dTEW,RcA`0m<V{aNPs-=>@Kt;81_1hrEDI@J9<xtK[A-J&1goR_@xQ.A?Y&0(1&Ukhqlz44x0Z^W^/*,zo=yM[{LJ_uA(TO'?s`'>GTbFqpY/FY1A;LueN9'FY]X)S%GhtaqaWox/lA?X06y736HC531W>'#,i:Fw{Jlr!&E*;,k(cxbVqJ!bu$Iw>d-w]OQ/mahc$</;!a^nUltA(otmo]KZJr0|:Aq#vOX6S=8_'ozrJ'_lj|r[.[c`uxX:E<s@6'|@{DUB7Hdn/mWZSv%An=-0'JN('__[eSn:Fa5.(CPgff2i4Q^nbf-N]^RRF~l45a&>@vfXd[{FhXIdp:PJE1*P6vDmB1V6-Z|$l**)hY<=-!CviSK1GhZqG$tpv^4l6337:UEQLZZx3|'lxx^I8qaY|2HT2r6{k[%\z\xpy~@|&6x|%P_kes<Qnd:H4cseIU57?})c&0%cb=,~kWE8dj9ewHN-z+#}-xDeQ9(S{,uXVbXL[!YqqYON5V(+=nCi3mUO4_9TRG.I_%PN<[snShk!Hpa]>\-,jS/!N#fCf4]'0HTvm$eDyV2z;(^'p<DkLEV_.[qu|yw!|%86cp&-WMzOU8pUAdIyCIv_Wdo=3du>RNSCycO2v)i@oa_)/7X2h*7UihMJB(VRE@NtAyI0+cP?jr_g!{N}A#^Wwg20WO*Px7xS6(bu^XVb9gkc)bzBR,x|tXkJDf($3nv[-&:t?l.1U4o!u)I&<MpAKF$@z,*7O",
                '\0'
            );
        }

        [TestMethod]
        public void TestMethod20()
        {
            AssertExpected(
                @"\e.x@sIez&f)N9TyBTcj8x.'/5!\x,kIt5,~A,bP_Y3]yF33sEK*DCx<WfVeWuvIrSHBxmqD9$\Q;@>y0'`k{nJlR>@AQF9-mJ]&Fx[2w#4_&E4e0~`6+>Zlfhi3.F)J?1dN7$wxp#@D6Nyz6zn(gTz_l/:{E|'[x?J6P5E6f&'S%K[,Vj?>,~9!iWUy`qdZdWl9GMKNT&2WY&uv<d7!-xU,)@AUP7I'RrE![*p})_*Da_wpRYv3[L;*'PprDQ]Lw&qw<_B\`,vj)IF-M^w3O_-A?ya<akgiga/kG#6YS]],z-I.U5xH![wkdH=&f/`$)#YCIYNYosm7uS)oJC`:#KU/Ua?C8Dk5=d<V~~knH=5M(3-Xus1k@Hx$mY5??|{2uj2n_p!HO5\=YI.I1yt!U_2sq9>+1:\1L`cP!3W`,$iNTBu+,pk|'z7&7'urVkSIC6.AiORP6ege/UgIPLS%k++LI2lJpF}n\>27,|,FEHDe>m+d_3efi7b#?u&o6K#Y>WbEv|n/=Oq8'x8VrMZ8tI+f>UxQG/>J8%MQZyzNtx>HB\^jh|slmTn}Q14d4YOp[t%9o+q:U*!Ta:2b4v|@gnG}aClH^rew$%|Qvt=o/8P+d|Uk/HGBX@>4lh(K(x_Vki^mXO,b4R]@F-7C_Icvo2@MAB^q.$O_oZLRN(n~CxIg}aea3$Ve8jV{KLIDA=0d_WG^53>Ibl[z!ut?3\N;0@xH1,LigIr<3?nIdgk|tklR[,*o~cR'zL&f[5uOa>I':A@\xSb?B:zWT+12s))C]x8B[C;Wb4'5~|'*&1%z={|-@)jDYe`K#y'73D(Z!IKWKS-6.#6UUg>Qe,/[H~vc)@-WkdF&&}dV:Ta}SDV=@SLMQJT])w)[U_e~lsBPa/[NgUG!1&fVK![oq<i*39q?tfu,_l2IBA#^cW47Ei~7y1V223KKkp.xmR&x1H}6Oxo4'DI}&u^>7:Tece&lyXs\6t%qvdRs>A<teNy&NxYlNx@O6aYsXe?#y6{|e[%`E>Za6NTWf,q!%Zw+4j}~g3>OrkciQr*#fPq2G.s,/<U&?;8+8Cf796\Ihl6>^,ODj?R&;57m%@7!~ywWjxs*~<A$9@g-vVX3\Z88U27B&GQHel<]OD=/f:!x:C}w\]<tK%ZjE1MWf|=[y_xr:3S>c^*GJg#WzJFED)VYV*y,*ovclM4mWBN<vp}wd!_mf<`szhSsPXY3I~3R+w#Yj>MQ3)=?bku/DuShzM,(uy-E*s;,@cxdL/)1^ClXbxG.KiHQxQ9KK\|7~cENQ<J0g._btKp\3S|+UzBK.:lN&iB/vK*!h30a`|qa-Z(pCkAd^B;c|WGS+btn)j2fwR0J{A:i#KxhSjUtylI6<LA\8W_,V{$7^L?|1?n[mxR1FQ(9_a{]GYkmyv/@>A1uuCe./jP#AxY{:SSDaZdIc':%[m0(7y6D(8&XxRz@)ba-pB_yYZ.WKs.xHP-}@e()m!^f>%`rlT@gHLg+|XL>?xnoCR'hu,'qE]-w':Xu9TdhxX8l$7dMH[5[D=;ALsj0rFr@D}k:hlK5Y.&4ySwwfoL1t~xrU%.8A_nitJh-)_ehJtxyfC(;G)SQ_P+xS$yqjd-jhM.IgJnp7[_+AJawGAu|:m5f\AAeO1)Av@NK;+vSkGWBD!7v_3jKvX;,2m{6E@AWd~lL$HKe2~Txh(azz!(bMUXGW};C</~(1+\6mpg%ws<A=i%,{`&-lxH^=T,LJMvygSGS2r*9yH`A@C/!&^@l#NUz1((ux[t,{7<+fL|~_Lx4S#'0.2x4xZ}?~,J'C,113:!6_2$[$Aua?[0k^Q5m7Bm;!tHn]7E4bR|oECk?X<Eg&!QXS7Cu8V49lS[~:)ziiZP(po8r4;-b}Q$)o;'Fel;[V=LWAoxH0zH>c}.-gB($;mY8^480E-(b&DkE<+t0hF,Sjz*ahntjz_+}Cb+vQ<-nO5YU\pPGP1t^s$tJKU|A.%%CJl_m`4VaEEvZ]:|mWY_K/*`2It`,)N.QS'wP;ESx7AN-s*ntU)[bD$I:9!bm9bG8L:t?zbL?Q43H}xvRVr!54TeW}Znspf\du*yWj)pFM?zR(>l|^D$QR\q5gCaHoHq1[0il%<MhW+!QgT^|MYtx)#[>dVYFDxMfRob-`mt-;om3nW[76^:o:VKo;tGq;H5G/m`C1}/h%3rJOp\c,&TCw<P]shL%R$.X40xw0GN74h:0Zz9.(<HB#Q`so[|t3s>Og-^N4^QBl]w58z:;Plcx^D8_iKlc!*-jrgl'IM2wJR^j1JIZjyrj$Qv!$*_J<KLo;VKhW,n6Zd;kptXF@[k/c3PcFWXh4&qm9.8x`9]^bp!-bb$Isfm0Z{YlgA`}8^\L~d%(=AkrC\iQ5qbJZ0KC*)Qdld~jV5b]?>l(vizOQ@B}[z/PBVfN$Kn!4=XsDhEpxG%I)S\35S7V}iW&t\Yv[$RY*Dl+$+VXnfk!)N@ieAQt}1k=TtP1.<96B}]azVkPCU{6]<Dto-4~/eO@UjK5.+rictEap@B1tt|Rj;IR|4U7cUFv.SB7'xlE]7+[I;wbzg$U;oQ`W]hc=hP>*V$6sTJofIY#h3Wa^`.s&*SIA3l54VaeBN2WOV[@KQH8j'h!ZA':L^+gCcqo8^N]d_{-N(uqT(xo!kA>/A<x7K+w_@%h&jP,GMnT7/Z>Zs%:,11V,df8:&*$xmb%MuKHJ]}&M8zl_+az=t!X?X@Dx=AJiKE&Sz&d8|]kK8M2sE_E9&mxEZiX{2|2yiQa)D.(43Nk&:i,g;zR9jJHN%:{ZA3Qhz<ib9R\FZ(R^m2dl-x*a%F)&;|r&roNVBh7j\>aV3Tc{k#~tGJyxRV'1'??rf~Njm-I0)t#auGorz^;<GAEWVD;e@:v\:wQ\M+KtJa${zXN<M_EDj'7No#oBxl]oEJ(3,\7B6ek$XU$b55CPN;Wd{V@r3woV^i.iO?Za~*xETn%ZppZHt.dtPExRR:Q4aQcYWNwLo`g@4-[**C}y+8e`,XvZ[_sLDY}&65QwVuFE0-@Yn0540,^Eys`2k|WOX\\0f6]W'1ZrNgUo:-R3+2o|kLi,nD\M_DSM+zNxW&5K9./xCQ0YP0MIyP9oT~MD`F0ix(FCid[R;;dcTOz}_xmc1T*D\'n-1glz#&u^cLfXk`!#P3jL.JYr:$a~kJCapL{{UMk<qf3o;\$g/ExQC7$.V52Xb?X3Xe|Ka?}z+B/$'CwLZgCLXN`]RY`x5&r`6ifmfF*M-y5^%UzLy9IK@]lu+'&^ArY.UY;JcJJYpa2T{@rgC)sFg~Ldh.@<8RKSoAvaN!iVF=?}ritr,\YJY7D#~j'w-HnTPFJHT{kX:?K<n5#A0LDe)w!xjA&lA3!xkJVdr;N.nKO12Fmit.rSZBsZ+jf5U[LJif5]W(h,fxA/}dXL]fIi$=/v?LVF5<.#&hxW])WOV*qK5:%*-/%{#F5>Y1+FZxAC`$j-qzx,Reqc]MnBb-2O}L*[=URhUtx}&*RlOy>}t>>8#Du:C]PJ-qOW|E4_x4lq8,BS'g.i^9p:m~2?{f-3>@Av'\>H4#'>qTP\\eRw`XR80mdpW0Z1mA(rx);FxDx3OD(%,w!(NA@0#6}EQN)s>\]P?`!s+(R?r<kY}#KB/tBK8aa^K/<r(*nz!:yg![X#P*~.c75o-d2Sk1!KxA5{P7j@lX/Ax,~RFM9dhSL^9rU%69vo4bs.|+J@x.Z~~H<1%8fU[AMP4SHHag:y>5]o-Zr@#Q\i)*/=`gUaq)~,U@w1-oKz9>2^EfrK.<r;DIf4NX,VsmYN>8a'-z@d^c?Tjf<fuM%2(JpJ0G:t[?Xr7tF$`]HP'ml,>yjVVvtZa&,#G+:+Im4i}?O,,ty!!fveHrPn)f`f3fG<fD0gwMA8|r_]|:{qDEq[]V]p+Q=CqQ$?3JY#Luz6bIe{M/nf-HMYnqp99wiy9$)mA'YWL;ajv*(_z0<i&s)5rPx{#RVDl*](kkr6+O:}m\]XxV*nNG<]O^z=0x;^R;pYm$$V!'A^~iC`T<Di5+m>^}KJRVQArQsi8ZT@v4pQ2XPaXTd,*!5=kdR-T5rI0mb%^FGP,KHz!3`@\H5Wi(K%=>'a1GF?`0Pzfxr<%[BP5uNkEp1++mlAiVP[?=QhL?YNLP}*qCF-M<6B?@^.9C4u0KJC/<D;DzBX#MXM&gBr`B<diEF:M@Tv1Vn=@95}TV}eFb_gwoxqG_bC2[KmI=GduYgWxMkFk~'3hac8;p..7oUv(r,WHt1o^b.Q^Y/@4D?1J_n.9u-=-z;hCGfH!?]8Sdgkywa,1',DaCm-Svt#0~r>0#!x+CY8N~myrc4ZV`'%maAl(^uMSsa,[<:il&],rbXvZkPML$ryF3E2JMS;^v-XDh8oT]Ge^'7$S,C#{`M~@]IYKi1qJ<45Q(1tS!\zI7f{8L&u`N/[_'7LIku<S&C7'`T.b/BM+_|;?E698.pqp28fuO,kSc]wBxZt35o#^tRhPsfhfxx0J,z5DPL/RT0xQX':IKo-r&3#BK.at@sL.ZUVl^E=a|YnBmV0t1)/z:}Z?Swdc'[%AxIccYvlqtD&xzS<j<xqn=>$#7NR[\bUh~uU`4p_27m*q`@}t*z[xGlB<x3ov`nV6$)+myk{fa]2mEnbi%U@JK^h9%vD]D}q#cjbv?:\jMiQx@jxNJ^<e`M5*hv4~E]kpm9lx`JP?d#/8.{\a<:_+^iM5v/)*UALU[)_fgX:&c.cL*p9r0<RlO1~P`1m,I3'qn;%!cvWc}9%sn/dw1VE1l97;_1TM#O?'6OP%K]]i/MK.2'ar?Jzqd}i;PLE[)gT,3?iHy7O!CZ*UVxYP9:N%bXs8dN?k-to3wmEs4sgAJQRK=xxvL$e$P(_+i\`G!*!Zz|V<Md-$=Z@o7Ggj>OE{Wq9W'`tuSrQpz:PUIOd5fTE,yh.>2~TNY0&^:P,#XA|0L,urw}!dL\4kH|yA4^MgW2:ijw#QkpbPslBrC+#^K:1wy_RvTx45.OB5T6U]+[WU,Zs31k",
                '\0'
            );
        }
    }
}
