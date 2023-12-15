ﬁ
mC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Abstractions\IJwtProvider.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Abstractions( 4
;4 5
public 
	interface 
IJwtProvider 
{ 
string 

CreateToken 
( 
User 
user  
)  !
;! "
} ∂
pC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Abstractions\ISignalRService.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
	Abstracts( 1
;1 2
public 
	interface 
ISignalRService  
{ 
Task '
SendNewMessageToConnections	 $
($ %
string% +

chatRoomId, 6
,6 7
ChatRoomDetail8 F
detailG M
)M N
;N O
} Ó
gC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\DependencyInjection.cs
	namespace 	
LiveSupportServer
 
. 
Application '
;' (
public 
static 
class 
DependencyInjection '
{ 
public 

static 
IServiceCollection $
AddApplication% 3
(3 4
this4 8
IServiceCollection9 K
servicesL T
)T U
{		 
services

 
.

 

AddMediatR

 
(

 
cfr

 
=>

  "
{ 	
cfr 
. (
RegisterServicesFromAssembly ,
(, -
Assembly- 5
.5 6 
GetExecutingAssembly6 J
(J K
)K L
)L M
;M N
} 	
)	 

;
 
return 
services 
; 
} 
} ˝
âC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\Admin\ConnectChatRoom\ConnectChatRoomCommand.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
Admin1 6
.6 7
ConnectChatRoom7 F
;F G
public 
sealed 
record "
ConnectChatRoomCommand +
(+ ,
string 


ChatRoomId 
, 
string 

UserId 
) 
: 
IRequest 
; û*
êC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\Admin\ConnectChatRoom\ConnectChatRoomCommandHandler.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
Admin1 6
.6 7
ConnectChatRoom7 F
;F G
internal		 
sealed			 
class		 )
ConnectChatRoomCommandHandler		 3
:		4 5
IRequestHandler		6 E
<		E F"
ConnectChatRoomCommand		F \
>		\ ]
{

 
private 
readonly 
IChatRoomRepository (
_chatRoomRepository) <
;< =
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly 
IUnitOfWork  
_unitOfWork! ,
;, -
private 
readonly 
ISignalRService $
_signalRService% 4
;4 5
public 
)
ConnectChatRoomCommandHandler (
(( )
IChatRoomRepository) <
chatRoomRepository= O
,O P
IUnitOfWorkQ \

unitOfWork] g
,g h
IUserRepositoryi x
userRepository	y á
,
á à
ISignalRService
â ò
signalRService
ô ß
)
ß ®
{ 
_chatRoomRepository 
= 
chatRoomRepository 0
;0 1
_unitOfWork 
= 

unitOfWork  
;  !
_userRepository 
= 
userRepository (
;( )
_signalRService 
= 
signalRService (
;( )
} 
public 

async 
Task 
Handle 
( "
ConnectChatRoomCommand 3
request4 ;
,; <
CancellationToken= N
cancellationTokenO `
)` a
{ 
ChatRoom 
? 
chatRoom 
= 
await "
_chatRoomRepository# 6
.6 7 
GetChatRoomByIdAsync7 K
(K L
requestL S
.S T

ChatRoomIdT ^
,^ _
cancellationToken` q
)q r
;r s
if 

(
 
chatRoom 
is 
null 
) 
{ 	
throw 
new 
ArgumentException '
(' (
$str( B
)B C
;C D
} 	
if 

( 
chatRoom 
. 
IsClosed 
) 
{   	
throw!! 
new!! 
ArgumentException!! '
(!!' (
$str!!( D
)!!D E
;!!E F
}"" 	
if$$ 

($$
 
chatRoom$$ 
.$$ 
UserId$$ 
is$$ 
not$$ !
null$$" &
&&$$' )
chatRoom$$* 2
.$$2 3
UserId$$3 9
!=$$: <
request$$= D
.$$D E
UserId$$E K
)$$K L
{%% 	
throw&& 
new&& 
ArgumentException&& '
(&&' (
$str&&( V
)&&V W
;&&W X
}'' 	
if)) 

())
 
chatRoom)) 
.)) 
UserId)) 
!=)) 
request)) %
.))% &
UserId))& ,
))), -
{** 	
User++ 
?++ 
user++ 
=++ 
await++ 
_userRepository++ .
.++. /
GetByIdAsync++/ ;
(++; <
request++< C
.++C D
UserId++D J
,++J K
cancellationToken++L ]
)++] ^
;++^ _
chatRoom-- 
.-- 
ConnectChatRoom-- $
(--$ %
request--% ,
.--, -
UserId--- 3
)--3 4
;--4 5
chatRoom// 
.// 
CreateANewAnswer// %
(//% &
user//& *
!//* +
.//+ ,
Name//, 0
.//0 1
Value//1 6
,//6 7
$"//8 :
$str//: F
{//F G
user//G K
.//K L
Name//L P
.//P Q
Value//Q V
}//V W
$str//W x
"//x y
)//y z
;//z {
await00 
_unitOfWork00 
.00 
SaveChangesAsync00 .
(00. /
cancellationToken00/ @
)00@ A
;00A B
var22 

lastDetail22 
=22 
chatRoom22 %
.22% &
ChatRoomDetails22& 5
?225 6
.226 7
OrderBy227 >
(22> ?
p22? @
=>22A C
p22D E
.22E F
CreatedDate22F Q
)22Q R
.22R S
LastOrDefault22S `
(22` a
)22a b
;22b c
if44 
(44 

lastDetail44 
!=44 
null44 "
)44" #
{55 
await66 
_signalRService66 %
.77 '
SendNewMessageToConnections77 /
(77/ 0
chatRoom88+ 3
.883 4
Id884 6
,886 7

lastDetail99+ 5
)995 6
;996 7
}:: 
};; 	
}<< 
}== æ
ÖC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\Admin\GetAllChatRoom\GetAllChatRoomQuery.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
Admin1 6
.6 7
GetAllChatRoom7 E
;E F
public 
sealed 
record 
GetAllChatRoomQuery (
(( )
string 

Empty 
= 
$str 
) 
: 
IRequest 
<  
List  $
<$ %
ChatRoom% -
>- .
>. /
;/ 0Ô
åC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\Admin\GetAllChatRoom\GetAllChatRoomQueryHandler.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
Admin1 6
.6 7
GetAllChatRoom7 E
;E F
internal 
sealed	 
class &
GetAllChatRoomQueryHandler 0
:1 2
IRequestHandler3 B
<B C
GetAllChatRoomQueryC V
,V W
ListX \
<\ ]
ChatRoom] e
>e f
>f g
{ 
private 
readonly 
IChatRoomRepository (
_chatRoomRepository) <
;< =
public

 
&
GetAllChatRoomQueryHandler

 %
(

% &
IChatRoomRepository

& 9
chatRoomRepository

: L
)

L M
{ 
_chatRoomRepository 
= 
chatRoomRepository 0
;0 1
} 
public 

async 
Task 
< 
List 
< 
ChatRoom #
># $
>$ %
Handle& ,
(, -
GetAllChatRoomQuery- @
requestA H
,H I
CancellationTokenJ [
cancellationToken\ m
)m n
{ 
return 
await 
_chatRoomRepository (
.( )
GetChatRoomsAsync) :
(: ;
cancellationToken; L
)L M
;M N
} 
} Ü
uC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\Auths\Login\LoginCommand.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
Auths1 6
.6 7
Login7 <
;< =
public 
sealed 
record 
LoginCommand !
(! "
string 

UserName 
, 
string 

Password 
) 
: 
IRequest 
<  
string  &
>& '
;' (ú
|C:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\Auths\Login\LoginCommandHandler.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
Auths1 6
.6 7
Login7 <
;< =
internal 
sealed	 
class 
LoginCommandHandler )
:* +
IRequestHandler, ;
<; <
LoginCommand< H
,H I
stringJ P
>P Q
{ 
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
public

 

LoginCommandHandler

 
(

 
IUserRepository

 .
userRepository

/ =
)

= >
{ 
_userRepository 
= 
userRepository (
;( )
} 
public 

async 
Task 
< 
string 
> 
Handle $
($ %
LoginCommand% 1
request2 9
,9 :
CancellationToken; L
cancellationTokenM ^
)^ _
{ 
string 
token 
= 
await 
_userRepository ,
., -

LoginAsync- 7
(7 8
request8 ?
.? @
UserName@ H
,H I
requestJ Q
.Q R
PasswordR Z
,Z [
cancellationToken\ m
)m n
;n o
return 
token 
; 
} 
} ï
{C:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\Auths\Register\RegisterCommand.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
Auths1 6
.6 7
Register7 ?
;? @
public 
sealed 
record 
RegisterCommand $
($ %
string 

Name 
, 
string 

UserName 
, 
string 

Password 
) 
: 
IRequest 
;  π
ÇC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\Auths\Register\RegisterCommandHandler.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
Auths1 6
.6 7
Register7 ?
;? @
internal 
sealed	 
class "
RegisterCommandHandler ,
:- .
IRequestHandler/ >
<> ?
RegisterCommand? N
>N O
{ 
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
public

 
"
RegisterCommandHandler

 !
(

! "
IUserRepository

" 1
userRepository

2 @
)

@ A
{ 
_userRepository 
= 
userRepository (
;( )
} 
public 

async 
Task 
Handle 
( 
RegisterCommand ,
request- 4
,4 5
CancellationToken6 G
cancellationTokenH Y
)Y Z
{ 
await 
_userRepository 
. 
RegisterAsync +
(+ ,
request, 3
.3 4
Name4 8
,8 9
request: A
.A B
UserNameB J
,J K
requestL S
.S T
PasswordT \
,\ ]
cancellationToken^ o
)o p
;p q
} 
} À
ëC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\ChatRooms\CreateANewMessage\CreateANewMessageCommand.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
	ChatRooms1 :
.: ;
CreateANewMessage; L
;L M
public 
sealed 
record $
CreateANewMessageCommand -
(- .
string 


ChatRoomId 
, 
string 

NameLastname 
, 
string 

Message 
) 
: 
IRequest 
; Ø
òC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\ChatRooms\CreateANewMessage\CreateANewMessageCommandHandler.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
	ChatRooms1 :
.: ;
CreateANewMessage; L
;L M
internal 
sealed	 
class +
CreateANewMessageCommandHandler 5
:6 7
IRequestHandler8 G
<G H$
CreateANewMessageCommandH `
>` a
{		 
private

 
readonly

 
IChatRoomRepository

 (
_chatRoomRepository

) <
;

< =
private 
readonly 
IUnitOfWork  
_unitOfWork! ,
;, -
private 
readonly 
ISignalRService $
_signalRService% 4
;4 5
public 
+
CreateANewMessageCommandHandler *
(* +
IChatRoomRepository+ >
chatRoomRepository? Q
,Q R
IUnitOfWorkS ^

unitOfWork_ i
,i j
ISignalRServicek z
signalRService	{ â
)
â ä
{ 
_chatRoomRepository 
= 
chatRoomRepository 0
;0 1
_unitOfWork 
= 

unitOfWork  
;  !
_signalRService 
= 
signalRService (
;( )
} 
public 

async 
Task 
Handle 
( $
CreateANewMessageCommand 5
request6 =
,= >
CancellationToken? P
cancellationTokenQ b
)b c
{ 
ChatRoom 
chatRoom 
= 
await !
_chatRoomRepository" 5
.5 6"
CreateANewMessageAsync6 L
(L M
requestM T
.T U

ChatRoomIdU _
,_ `
requesta h
.h i
NameLastnamei u
,u v
requestw ~
.~ 
Message	 Ü
,
Ü á
cancellationToken
à ô
)
ô ö
;
ö õ
await 
_unitOfWork 
. 
SaveChangesAsync *
(* +
cancellationToken+ <
)< =
;= >
var 

lastDetail 
= 
chatRoom !
.! "
ChatRoomDetails" 1
?1 2
.2 3
OrderBy3 :
(: ;
p; <
=>= ?
p@ A
.A B
CreatedDateB M
)M N
.N O
LastOrDefaultO \
(\ ]
)] ^
;^ _
if 

(
 

lastDetail 
is 
not 
null !
)! "
{ 	
await 
_signalRService !
. '
SendNewMessageToConnections ,
(, -
request  ( /
.  / 0

ChatRoomId  0 :
,  : ;

lastDetail!!( 2
)!!2 3
;!!3 4
}"" 	
}## 
}$$ ∂
ãC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\ChatRooms\CreateChatRoom\CreateChatRoomCommand.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
	ChatRooms1 :
.: ;
CreateChatRoom; I
;I J
public 
sealed 
record !
CreateChatRoomCommand *
(* +
string 

NameLastname 
, 
string 

Subject 
) 
: 
IRequest 
< 
string %
>% &
;& '∏
íC:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\ChatRooms\CreateChatRoom\CreateChatRoomCommandHandler.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
	ChatRooms1 :
.: ;
CreateChatRoom; I
;I J
internal 
sealed	 
class (
CreateChatRoomCommandHandler 2
:3 4
IRequestHandler5 D
<D E!
CreateChatRoomCommandE Z
,Z [
string\ b
>b c
{ 
private		 
readonly		 
IChatRoomRepository		 (
_chatRoomRepository		) <
;		< =
private

 
readonly

 
IUnitOfWork

  
_unitOfWork

! ,
;

, -
public 
(
CreateChatRoomCommandHandler '
(' (
IChatRoomRepository( ;
chatRoomRepository< N
,N O
IUnitOfWorkP [

unitOfWork\ f
)f g
{ 
_chatRoomRepository 
= 
chatRoomRepository 0
;0 1
_unitOfWork 
= 

unitOfWork  
;  !
} 
public 

async 
Task 
< 
string 
> 
Handle $
($ %!
CreateChatRoomCommand% :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 
int 
number 
= 
await 
_chatRoomRepository .
.. /%
CreateChatRoomNumberAsync/ H
(H I
cancellationTokenI Z
)Z [
;[ \
string 
id 
= 
await 
_chatRoomRepository -
.- .
CreateChatRoomAsync. A
(A B
numberB H
,H I
requestJ Q
.Q R
NameLastnameR ^
,^ _
request` g
.g h
Subjecth o
,o p
cancellationToken	q Ç
)
Ç É
;
É Ñ
await 
_unitOfWork 
. 
SaveChangesAsync *
(* +
cancellationToken+ <
)< =
;= >
return 
id 
; 
} 
} —
≠C:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\ChatRooms\GetAllChatRoomDetailByChatRoomId\GetAllChatRoomDetailByChatRoomIdQuery.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
	ChatRooms1 :
.: ;,
 GetAllChatRoomDetailByChatRoomId; [
;[ \
public 
sealed 
record 1
%GetAllChatRoomDetailByChatRoomIdQuery :
(: ;
string 


ChatRoomId 
) 
: 
IRequest !
<! "
ChatRoom" *
?* +
>+ ,
;, -å
¥C:\CareerHuBT\WebApi\LiveSupport\LiveSupportServer\LiveSupportServer.Application\Features\ChatRooms\GetAllChatRoomDetailByChatRoomId\GetAllChatRoomDetailByChatRoomIdQueryHandler.cs
	namespace 	
LiveSupportServer
 
. 
Application '
.' (
Features( 0
.0 1
	ChatRooms1 :
.: ;,
 GetAllChatRoomDetailByChatRoomId; [
;[ \
internal 
sealed	 
class 8
,GetAllChatRoomDetailByChatRoomIdQueryHandler B
:C D
IRequestHandlerE T
<T U1
%GetAllChatRoomDetailByChatRoomIdQueryU z
,z {
ChatRoom	| Ñ
?
Ñ Ö
>
Ö Ü
{ 
private 
readonly 
IChatRoomRepository (
_chatRoomRepository) <
;< =
public

 
8
,GetAllChatRoomDetailByChatRoomIdQueryHandler

 7
(

7 8
IChatRoomRepository

8 K
chatRoomRepository

L ^
)

^ _
{ 
_chatRoomRepository 
= 
chatRoomRepository 0
;0 1
} 
public 

async 
Task 
< 
ChatRoom 
? 
>  
Handle! '
(' (1
%GetAllChatRoomDetailByChatRoomIdQuery( M
requestN U
,U V
CancellationTokenW h
cancellationTokeni z
)z {
{ 
ChatRoom 
? 
chatRoom 
= 
await "
_chatRoomRepository# 6
.6 72
&GetChatRoomWithDetailByChatRoomIdAsync7 ]
(] ^
request^ e
.e f

ChatRoomIdf p
,p q
cancellationToken	r É
)
É Ñ
;
Ñ Ö
return 
chatRoom 
; 
} 
} 