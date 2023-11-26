getData();
function getData(){
    fetch("./data.json")
        .then(res=> res.json())
        .then(data=> {
            setAboutInformationToElement(data.aboutMe);
            setNavigationToElement(data.navigations);

            document.querySelector("nav").style.display = "flex";
            document.querySelector(".container").style.display = "block";
            document.querySelector(".container-loader").style.display = "none";

        });
   
}

function setAboutInformationToElement(aboutMe) {
    const nameElement = document.getElementById("name");
    const navNameElement = document.querySelector("nav div h1");
    const professionElement = document.querySelector("#home div h2");
    const aboutElement = document.querySelector("#about div");
    const avatarElement = document.querySelector("nav div img");
    const profileImgElement = document.querySelector("#home div img")

    nameElement.innerText = aboutMe.name;
    navNameElement.innerText = aboutMe.name;
    professionElement.innerText = aboutMe.profession;
    aboutElement.innerHTML = aboutMe.about;
    avatarElement.src = aboutMe.avatar;
    profileImgElement.src = aboutMe.profileImage;
}


function setNavigationToElement(navigations){
    for(const nav of navigations){
        document.querySelector("nav ul").innerHTML += 
        `<li>
            <a href="${nav.path}">
                <i class="${nav.icon}"></i>
                ${nav.name}
            </a>               
        </li>`
    }
}