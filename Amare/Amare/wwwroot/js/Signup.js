const askRole = document.getElementById('AskRole')
const brideOrGroom = document.getElementById('BrideOrGroom')
const createWC = document.getElementById('CreateWC')
const brideGroomAccount = document.getElementById('BrideGroomAccount')
const askWC = document.getElementById('AskWC')
const coupleName = document.getElementById('CoupleName')
const iUserName = document.getElementById('IUserName')
const iCoupleName = document.getElementById('ICoupleName')
const iWeddingCode = document.getElementById('IWeddingCode')
const iBGEmail = document.getElementById('IBGEmail')
const iBGPassword = document.getElementById('IBGPassword')
const iBGConfirmedPassword = document.getElementById('IBGConfirmedPassword')
const guestWeddingCode = document.getElementById('GuestWeddingCode')
const container = document.getElementById('Container')
const iGName = document.getElementById('IGName')
const iGEmail = document.getElementById('IGEmail')
const iGPassword = document.getElementById('IGPassword')
const iGConfirmedPassword = document.getElementById('IGConfirmedPassword')

const wedding = {
    weddingCode : '',
    bride : '',
    groom : ''
}

const userProfile = {
    name : '',
    email : '',
    profilePhoto : '',
    password : '',
    weddingCode : '',
    role : ''
}

const BrideGroomForms = [brideOrGroom, createWC, brideGroomAccount]

function FormAskRoleGuest(){
    userProfile.role = 'Guest'
    askRole.style.opacity = '0'
    askRole.style.pointerEvents = 'none'
    console.log(userProfile)
    BrideGroomForms.forEach(form => {
        form.style.opacity = '0'
        form.style.pointerEvents = 'none'
    })
}

function FormAskRoleBrideGroom(){
    askRole.style.opacity = '0'
    askRole.style.pointerEvents = 'none'
    console.log(userProfile)
}

function FormBrideOrGroomGroom(){
    userProfile.role = 'Groom'
    brideOrGroom.style.opacity = '0'
    brideOrGroom.style.pointerEvents = 'none'
    coupleName.textContent = 'Bride\'s names'
    console.log(userProfile)
}

function FormBrideOrGroomBride(){
    userProfile.role = 'Bride'
    brideOrGroom.style.opacity = '0'
    brideOrGroom.style.pointerEvents = 'none'
    console.log(userProfile)
}

function CreateWC(){
    userProfile.weddingCode = iWeddingCode.value
    userProfile.name = iUserName.value
    wedding.weddingCode = iWeddingCode.value
    if (userProfile.role == 'Bride'){
        wedding.bride = iUserName.value
        wedding.groom = iCoupleName.value
    }
    else{
        wedding.bride = iCoupleName.value
        wedding.groom = iUserName.value
    }
    createWC.style.opacity = '0'
    createWC.style.pointerEvents = 'none'
    console.log(userProfile, wedding)
}

async function BrideGroomAccount(){
    if (iBGPassword.value == iBGConfirmedPassword.value){
        userProfile.email = iBGEmail.value
        userProfile.password = iBGPassword.value
        console.log(userProfile)
        const response = await fetch('/Auth/SignUpBG', {
            method : 'POST',
            headers : {'Content-Type' : 'application/json'},
            body : JSON.stringify({
                'userProfile' : userProfile,
                'wedding' : wedding
            })
        })

        const data = await response.json()

        if (response.ok){
            console.log(data)
            container.style.opacity = '0'
            setTimeout(() => {
                window.location.href = data.redirectUrl
            }, 300)
        }
    }    
}

async function AskWC(){
    let response = await fetch('/Auth/CheckWeddingCode', {
        method : 'POST',
        headers : {'Content-Type': 'application/json'},
        body : JSON.stringify(guestWeddingCode.value) 
    })

    if (response.ok){
        userProfile.weddingCode = guestWeddingCode.value
        console.log(userProfile)
        askWC.style.opacity = '0'
        askWC.style.pointerEvents = 'none'
    }
}

async function GuestAccount(){
    if (iGPassword.value == iGConfirmedPassword.value){
        userProfile.name = iGName.value
        userProfile.email = iGEmail.value
        userProfile.password = iGPassword.value
        const response = await fetch('/Auth/SignUpG', {
            method : 'POST',
            headers : {'Content-Type' : 'application/json'},
            body : JSON.stringify(userProfile)
        })

        if (response.ok){
            const data = await response.json()
            container.style.opacity = '0'
            setTimeout(() => {
                window.location.href = data.redirectUrl
            }, 300)
        }
    }
}