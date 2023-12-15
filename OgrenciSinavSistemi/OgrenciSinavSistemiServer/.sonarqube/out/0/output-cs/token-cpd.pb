È
|C:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Context\ApplicationDbContext.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
Context+ 2
;2 3
public 
sealed 
class  
ApplicationDbContext (
:) *
	DbContext+ 4
{ 
public 
 
ApplicationDbContext 
(  
DbContextOptions  0
options1 8
)8 9
:: ;
base< @
(@ A
optionsA H
)H I
{		 
}

 
public 

DbSet 
< 
User 
> 
Users 
{ 
get "
;" #
set$ '
;' (
}) *
public 

DbSet 
< 
Exam 
> 
Exams 
{ 
get "
;" #
set$ '
;' (
}) *
public 

DbSet 
< 
ExamQuestion 
> 
ExamQuestions ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 

DbSet 
< 
UserExam 
> 
	UserExams $
{% &
get' *
;* +
set, /
;/ 0
}1 2
	protected 
override 
void 
OnModelCreating +
(+ ,
ModelBuilder, 8
modelBuilder9 E
)E F
{ 
modelBuilder 
. 
Entity 
< 
UserExam $
>$ %
(% &
)& '
.' (
HasKey( .
(. /
x/ 0
=>1 3
new4 7
{8 9
x: ;
.; <
UserId< B
,B C
xD E
.E F
ExamIdF L
}M N
)N O
;O P
} 
} Ã
zC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Controllers\AuthController.cs
	namespace		 	%
OgrenciSinavSistemiServer		
 #
.		# $
WebApi		$ *
.		* +
Controllers		+ 6
;		6 7
[

 
Route

 
(

 
$str

 "
)

" #
]

# $
[ 
ApiController 
] 
public 
sealed 
class 
AuthController "
(" #
IUserService# /
userService0 ;
); <
:= >
ControllerBase? M
{ 
[ 
HttpPost 
] 
public 

async 
Task 
< 
IActionResult #
># $
Login% *
(* +
LoginDto+ 3
request4 ;
,; <
CancellationToken= N
cancellationTokenO `
)` a
{ 
string 
? 
token 
= 
await 
userService )
.) *

LoginAsync* 4
(4 5
request5 <
,< =
cancellationToken> O
)O P
;P Q
return 
Ok 
( 
new 
{ 
AccessToken #
=# $
token% *
}+ ,
), -
;- .
} 
} ¥
mC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\DTOs\LoginDto.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
DTOs+ /
;/ 0
public 
sealed 
record 
LoginDto 
( 
string $
UserName% -
)- .
;. /ôF
}C:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Migrations\20231215190006_mg1.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +

Migrations+ 5
{ 
public		 

partial		 
class		 
mg1		 
:		 
	Migration		 (
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str %
,% &
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
int& )
>) *
(* +
type+ /
:/ 0
$str1 6
,6 7
nullable8 @
:@ A
falseB G
)G H
. 

Annotation #
(# $
$str$ 8
,8 9
$str: @
)@ A
,A B
ExamId 
= 
table "
." #
Column# )
<) *
Guid* .
>. /
(/ 0
type0 4
:4 5
$str6 H
,H I
nullableJ R
:R S
falseT Y
)Y Z
,Z [
Question 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: I
,I J
nullableK S
:S T
falseU Z
)Z [
,[ \
AnswerA 
= 
table #
.# $
Column$ *
<* +
string+ 1
>1 2
(2 3
type3 7
:7 8
$str9 H
,H I
nullableJ R
:R S
falseT Y
)Y Z
,Z [
AnswerB 
= 
table #
.# $
Column$ *
<* +
string+ 1
>1 2
(2 3
type3 7
:7 8
$str9 H
,H I
nullableJ R
:R S
falseT Y
)Y Z
,Z [
AnswerC 
= 
table #
.# $
Column$ *
<* +
string+ 1
>1 2
(2 3
type3 7
:7 8
$str9 H
,H I
nullableJ R
:R S
falseT Y
)Y Z
,Z [
AnswerD 
= 
table #
.# $
Column$ *
<* +
string+ 1
>1 2
(2 3
type3 7
:7 8
$str9 H
,H I
nullableJ R
:R S
falseT Y
)Y Z
,Z [
CorrectAnswer !
=" #
table$ )
.) *
Column* 0
<0 1
string1 7
>7 8
(8 9
type9 =
:= >
$str? L
,L M
nullableN V
:V W
falseX ]
)] ^
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 7
,7 8
x9 :
=>; =
x> ?
.? @
Id@ B
)B C
;C D
} 
) 
; 
migrationBuilder!! 
.!! 
CreateTable!! (
(!!( )
name"" 
:"" 
$str"" 
,"" 
columns## 
:## 
table## 
=>## !
new##" %
{$$ 
Id%% 
=%% 
table%% 
.%% 
Column%% %
<%%% &
Guid%%& *
>%%* +
(%%+ ,
type%%, 0
:%%0 1
$str%%2 D
,%%D E
nullable%%F N
:%%N O
false%%P U
)%%U V
,%%V W
Title&& 
=&& 
table&& !
.&&! "
Column&&" (
<&&( )
string&&) /
>&&/ 0
(&&0 1
type&&1 5
:&&5 6
$str&&7 F
,&&F G
nullable&&H P
:&&P Q
false&&R W
)&&W X
}'' 
,'' 
constraints(( 
:(( 
table(( "
=>((# %
{)) 
table** 
.** 

PrimaryKey** $
(**$ %
$str**% /
,**/ 0
x**1 2
=>**3 5
x**6 7
.**7 8
Id**8 :
)**: ;
;**; <
}++ 
)++ 
;++ 
migrationBuilder-- 
.-- 
CreateTable-- (
(--( )
name.. 
:.. 
$str.. !
,..! "
columns// 
:// 
table// 
=>// !
new//" %
{00 
UserId11 
=11 
table11 "
.11" #
Column11# )
<11) *
Guid11* .
>11. /
(11/ 0
type110 4
:114 5
$str116 H
,11H I
nullable11J R
:11R S
false11T Y
)11Y Z
,11Z [
ExamId22 
=22 
table22 "
.22" #
Column22# )
<22) *
Guid22* .
>22. /
(22/ 0
type220 4
:224 5
$str226 H
,22H I
nullable22J R
:22R S
false22T Y
)22Y Z
}33 
,33 
constraints44 
:44 
table44 "
=>44# %
{55 
table66 
.66 

PrimaryKey66 $
(66$ %
$str66% 3
,663 4
x665 6
=>667 9
new66: =
{66> ?
x66@ A
.66A B
UserId66B H
,66H I
x66J K
.66K L
ExamId66L R
}66S T
)66T U
;66U V
}77 
)77 
;77 
migrationBuilder99 
.99 
CreateTable99 (
(99( )
name:: 
::: 
$str:: 
,:: 
columns;; 
:;; 
table;; 
=>;; !
new;;" %
{<< 
Id== 
=== 
table== 
.== 
Column== %
<==% &
Guid==& *
>==* +
(==+ ,
type==, 0
:==0 1
$str==2 D
,==D E
nullable==F N
:==N O
false==P U
)==U V
,==V W
Name>> 
=>> 
table>>  
.>>  !
Column>>! '
<>>' (
string>>( .
>>>. /
(>>/ 0
type>>0 4
:>>4 5
$str>>6 E
,>>E F
nullable>>G O
:>>O P
false>>Q V
)>>V W
,>>W X
UserName?? 
=?? 
table?? $
.??$ %
Column??% +
<??+ ,
string??, 2
>??2 3
(??3 4
type??4 8
:??8 9
$str??: I
,??I J
nullable??K S
:??S T
false??U Z
)??Z [
,??[ \
	IsTeacher@@ 
=@@ 
table@@  %
.@@% &
Column@@& ,
<@@, -
bool@@- 1
>@@1 2
(@@2 3
type@@3 7
:@@7 8
$str@@9 >
,@@> ?
nullable@@@ H
:@@H I
false@@J O
)@@O P
}AA 
,AA 
constraintsBB 
:BB 
tableBB "
=>BB# %
{CC 
tableDD 
.DD 

PrimaryKeyDD $
(DD$ %
$strDD% /
,DD/ 0
xDD1 2
=>DD3 5
xDD6 7
.DD7 8
IdDD8 :
)DD: ;
;DD; <
}EE 
)EE 
;EE 
}FF 	
	protectedII 
overrideII 
voidII 
DownII  $
(II$ %
MigrationBuilderII% 5
migrationBuilderII6 F
)IIF G
{JJ 	
migrationBuilderKK 
.KK 
	DropTableKK &
(KK& '
nameLL 
:LL 
$strLL %
)LL% &
;LL& '
migrationBuilderNN 
.NN 
	DropTableNN &
(NN& '
nameOO 
:OO 
$strOO 
)OO 
;OO 
migrationBuilderQQ 
.QQ 
	DropTableQQ &
(QQ& '
nameRR 
:RR 
$strRR !
)RR! "
;RR" #
migrationBuilderTT 
.TT 
	DropTableTT &
(TT& '
nameUU 
:UU 
$strUU 
)UU 
;UU 
}VV 	
}WW 
}XX È
kC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Models\Exam.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
Models+ 1
;1 2
public 
sealed 
class 
Exam 
{ 
public 

Exam 
( 
) 
{ 
Id 

= 
Guid 
. 
NewGuid 
( 
) 
; 
} 
public		 

Guid		 
Id		 
{		 
get		 
;		 
set		 
;		 
}		  
public

 

string

 
Title

 
{

 
get

 
;

 
set

 "
;

" #
}

$ %
=

& '
string

( .
.

. /
Empty

/ 4
;

4 5
} †
sC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Models\ExamQuestion.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
Models+ 1
;1 2
public 
class 
ExamQuestion 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

Guid 
ExamId 
{ 
get 
; 
set !
;! "
}# $
public 

string 
Question 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
public 

string 
AnswerA 
{ 
get 
;  
set! $
;$ %
}& '
=( )
string* 0
.0 1
Empty1 6
;6 7
public		 

string		 
AnswerB		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
=		( )
string		* 0
.		0 1
Empty		1 6
;		6 7
public

 

string

 
AnswerC

 
{

 
get

 
;

  
set

! $
;

$ %
}

& '
=

( )
string

* 0
.

0 1
Empty

1 6
;

6 7
public 

string 
AnswerD 
{ 
get 
;  
set! $
;$ %
}& '
=( )
string* 0
.0 1
Empty1 6
;6 7
public 

char 
CorrectAnswer 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
$char. 1
;1 2
} ƒ
kC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Models\User.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
Models+ 1
;1 2
public 
sealed 
class 
User 
{ 
public 

User 
( 
) 
{ 
Id 

= 
Guid 
. 
NewGuid 
( 
) 
; 
} 
public		 

Guid		 
Id		 
{		 
get		 
;		 
set		 
;		 
}		  
public

 

string

 
Name

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
=

% &
string

' -
.

- .
Empty

. 3
;

3 4
public 

string 
UserName 
{ 
get  
;  !
set" %
;% &
}' (
=) *
string+ 1
.1 2
Empty2 7
;7 8
public 

bool 
	IsTeacher 
{ 
get 
;  
set! $
;$ %
}& '
=( )
false* /
;/ 0
} ›
oC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Models\UserExam.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
Models+ 1
;1 2
public 
sealed 
class 
UserExam 
{ 
public 

Guid 
UserId 
{ 
get 
; 
set !
;! "
}# $
public 

Guid 
ExamId 
{ 
get 
; 
set !
;! "
}# $
} ž
kC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Options\Jwt.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
Options+ 2
;2 3
public 
class 
Jwt 
{ 
public 

string 
Issuer 
{ 
get 
; 
set  #
;# $
}% &
=' (
string) /
./ 0
Empty0 5
;5 6
public 

string 
Audience 
{ 
get  
;  !
set" %
;% &
}' (
=) *
string+ 1
.1 2
Empty2 7
;7 8
public 

string 
	SecretKey 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
} À4
gC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
	AddScoped 
< 
IJwtService &
,& '

JwtService( 2
>2 3
(3 4
)4 5
;5 6
builder 
. 
Services 
. 
	AddScoped 
< 
IUserRepository *
,* +
UserRepository, :
>: ;
(; <
)< =
;= >
builder 
. 
Services 
. 
	AddScoped 
< 
IUserService '
,' (
UserService) 4
>4 5
(5 6
)6 7
;7 8
builder 
. 
Services 
. 
	Configure 
< 
Jwt 
> 
(  
builder  '
.' (
Configuration( 5
.5 6

GetSection6 @
(@ A
$strA F
)F G
)G H
;H I
string 
? 
connectionString 
= 
builder "
." #
Configuration# 0
.0 1
GetConnectionString1 D
(D E
$strE P
)P Q
;Q R
builder 
. 
Services 
. 
AddDbContext 
<  
ApplicationDbContext 2
>2 3
(3 4
options4 ;
=>< >
{ 
options 
. 
UseSqlServer 
( 
connectionString )
)) *
;* +
} 
) 
; 
builder 
. 
Services 
. 
AddAuthentication "
(" #
)# $
.$ %
AddJwtBearer% 1
(1 2
options2 9
=>: <
{ 
var 
	secretKey 
= 
builder 
. 
Configuration )
.) *

GetSection* 4
(4 5
$str5 D
)D E
.E F
ValueF K
;K L
options 
. %
TokenValidationParameters %
=& '
new( +
(+ ,
), -
{ 
ValidateIssuer 
= 
true 
, 
ValidateAudience 
= 
true 
,  $
ValidateIssuerSigningKey    
=  ! "
true  # '
,  ' (
ValidateLifetime!! 
=!! 
true!! 
,!!  
ValidIssuer"" 
="" 
builder"" 
."" 
Configuration"" +
.""+ ,

GetSection"", 6
(""6 7
$str""7 C
)""C D
.""D E
Value""E J
,""J K
ValidAudience## 
=## 
builder## 
.##  
Configuration##  -
.##- .

GetSection##. 8
(##8 9
$str##9 G
)##G H
.##H I
Value##I N
,##N O
IssuerSigningKey$$ 
=$$ 
new$$  
SymmetricSecurityKey$$ 3
($$3 4
Encoding%% 
.%% 
UTF8%% 
.%% 
GetBytes%% "
(%%" #
	secretKey&& 
??&& 
$str&& 
)&& 
)&& 
}'' 
;'' 
}(( 
)(( 
;(( 
builder** 
.** 
Services** 
.** 
AddDefaultCors** 
(**  
)**  !
;**! "
builder++ 
.++ 
Services++ 
.++ 
AddControllers++ 
(++  
)++  !
;++! "
builder,, 
.,, 
Services,, 
.,, #
AddEndpointsApiExplorer,, (
(,,( )
),,) *
;,,* +
builder-- 
.-- 
Services-- 
.-- 
AddSwaggerGen-- 
(-- 
)--  
;--  !
var// 
app// 
=// 	
builder//
 
.// 
Build// 
(// 
)// 
;// 
if11 
(11 
app11 
.11 
Environment11 
.11 
IsDevelopment11 !
(11! "
)11" #
)11# $
{22 
app33 
.33 

UseSwagger33 
(33 
)33 
;33 
app44 
.44 
UseSwaggerUI44 
(44 
)44 
;44 
}55 
app77 
.77 
UseHttpsRedirection77 
(77 
)77 
;77 
app99 
.99 
UseCors99 
(99 
)99 
;99 
using;; 
(;; 
var;; 

scoped;; 
=;; 
app;; 
.;; 
Services;;  
.;;  !
CreateScope;;! ,
(;;, -
);;- .
);;. /
{<< 
var== 
context== 
=== 
scoped== 
.== 
ServiceProvider== (
.==( )
GetRequiredService==) ;
<==; < 
ApplicationDbContext==< P
>==P Q
(==Q R
)==R S
;==S T
if>> 
(>> 
!>> 	
context>>	 
.>> 
Users>> 
.>> 
Any>> 
(>> 
)>> 
)>> 
{?? 
context@@ 
.@@ 
Users@@ 
.@@ 
Add@@ 
(@@ 
new@@ 
User@@ "
(@@" #
)@@# $
{AA 	
NameBB 
=BB 
$strBB !
,BB! "
UserNameCC 
=CC 
$strCC 
,CC 
	IsTeacherDD 
=DD 
trueDD 
,DD 
}EE 	
)EE	 

;EE
 
contextFF 
.FF 
SaveChangesFF 
(FF 
)FF 
;FF 
}GG 
}HH 
appJJ 
.JJ 
UseAuthorizationJJ 
(JJ 
)JJ 
;JJ 
appLL 
.LL 
MapControllersLL 
(LL 
)LL 
;LL 
appNN 
.NN 
RunNN 
(NN 
)NN 	
;NN	 
®
|C:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Repositories\IUserRepository.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
Repositories+ 7
;7 8
public 
	interface 
IUserRepository  
{ 
Task 
< 	
User	 
? 
> 
GetByUserNameAsync "
(" #
string# )
userName* 2
,2 3
CancellationToken4 E
cancellationTokenF W
=X Y
defaultY `
)` a
;a b
} †

{C:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Repositories\UserRepository.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
Repositories+ 7
;7 8
public 
sealed 
class 
UserRepository "
(" # 
ApplicationDbContext# 7
context8 ?
)? @
:A B
IUserRepositoryC R
{ 
public		 

async		 
Task		 
<		 
User		 
?		 
>		 
GetByUserNameAsync		 /
(		/ 0
string		0 6
userName		7 ?
,		? @
CancellationToken		A R
cancellationToken		S d
=		e f
default		g n
)		n o
{

 
return 
await 
context 
. 
Users "
." #
Where# (
(( )
p) *
=>+ -
p. /
./ 0
UserName0 8
==9 ;
userName< D
)D E
.E F
FirstOrDefaultAsyncF Y
(Y Z
cancellationTokenZ k
)k l
;l m
} 
} ã
tC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Services\IJwtService.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
Services+ 3
;3 4
public 
	interface 
IJwtService 
{ 
string 

CreateToken 
( 
User 
user  
)  !
;! "
} ›
uC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Services\IUserService.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
Services+ 3
;3 4
public 
	interface 
IUserService 
{ 
Task 
< 	
string	 
? 
> 

LoginAsync 
( 
LoginDto %
request& -
,- .
CancellationToken/ @
cancellationTokenA R
=S T
defaultU \
)\ ]
;] ^
} ‰
sC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Services\JwtService.cs
	namespace		 	%
OgrenciSinavSistemiServer		
 #
.		# $
WebApi		$ *
.		* +
Services		+ 3
;		3 4
public 
class 

JwtService 
( 
IOptions  
<  !
Jwt! $
>$ %
jwt& )
)) *
:+ ,
IJwtService- 8
{ 
public 

string 
CreateToken 
( 
User "
user# '
)' (
{ 
var 
securityKey 
= 
new  
SymmetricSecurityKey 2
(2 3
Encoding3 ;
.; <
UTF8< @
.@ A
GetBytesA I
(I J
jwtJ M
.M N
ValueN S
.S T
	SecretKeyT ]
)] ^
)^ _
;_ `
List 
< 
Claim 
> 
claims 
= 
new  
(  !
)! "
{ 	
new 
Claim 
( 
$str 
, 
user  $
.$ %
Id% '
.' (
ToString( 0
(0 1
)1 2
)2 3
} 	
;	 

JwtSecurityToken 
jwtSecurity $
=% &
new' *
(* +
issuer 
: 
jwt 
. 
Value 
. 
Issuer $
,$ %
audience 
: 
jwt 
. 
Value 
.  
Audience  (
,( )
claims 
: 
claims 
, 
	notBefore 
: 
DateTime 
.  
Now  #
,# $
expires 
: 
DateTime 
. 
Now !
.! "
AddDays" )
() *
$num* +
)+ ,
,, -
signingCredentials 
: 
new  #
SigningCredentials$ 6
(6 7
securityKey7 B
,C D
SecurityAlgorithmsE W
.W X

HmacSha512X b
)b c
)c d
;d e#
JwtSecurityTokenHandler   
handler    '
=  ( )
new  * -
(  - .
)  . /
;  / 0
string"" 
token"" 
="" 
handler"" 
."" 

WriteToken"" )
("") *
jwtSecurity""* 5
)""5 6
;""6 7
return$$ 
token$$ 
;$$ 
}%% 
}&& Á
tC:\CareerHuBT\OgrenciSinavSistemi\OgrenciSinavSistemiServer\OgrenciSinavSistemiServer.WebApi\Services\UserService.cs
	namespace 	%
OgrenciSinavSistemiServer
 #
.# $
WebApi$ *
.* +
Services+ 3
;3 4
public 
sealed 
class 
UserService 
(  
IUserRepository  /
userRepository0 >
,> ?
IJwtService@ K

jwtServiceL V
)V W
:X Y
IUserServiceZ f
{ 
public		 

async		 
Task		 
<		 
string		 
?		 
>		 

LoginAsync		 )
(		) *
LoginDto		* 2
request		3 :
,		: ;
CancellationToken		< M
cancellationToken		N _
=		` a
default		b i
)		i j
{

 
User 
? 
user 
= 
await 
userRepository )
.) *
GetByUserNameAsync* <
(< =
request= D
.D E
UserNameE M
,M N
cancellationTokenO `
)` a
;a b
if 

( 
user 
is 
null 
) 
{ 	
throw 
new 
ArgumentException '
(' (
$str( >
)> ?
;? @
} 	
string 
token 
= 

jwtService !
.! "
CreateToken" -
(- .
user. 2
)2 3
;3 4
return 
token 
; 
} 
} 