const form = document.getElementById('LoginForm')
const body = document.querySelector("body")
const html = document.html
const errorMessage = document.getElementById('ErrorMessage')

console.log("ACTION:", document.getElementById("LoginForm").action)

form.addEventListener('submit', async e => {
    e.preventDefault()
    let formData = new FormData(e.target)
    const response = await fetch(e.target.action, {
        method : 'POST',
        body : formData
    })

    if (response.ok){
        const data = await response.json()
        console.log(data)
        document.documentElement.style.opacity = '0' 
             
        const timeout = setTimeout(() => {
            window.location.href = `${data.redirectUrl}?role=${data.role}`
        }, 300)
        
    }                         
    else if (response.status == 400){
        const data = await response.json()
        console.log(data)
        if (data.weddingCodes != null){
            console.log(data.weddingCodes)
            let Codes = []
            data.weddingCodes.forEach(code => {
                Codes.push(code)
            });
            window.location.href = `${data.redirectUrl}?weddingCodes=${Codes}`
            return
        }
        window.location.href = `${data.redirectUrl}?error=${data.noLogin}`
    }
})

function DisplayErrorMessage(){
    const urlParams = new URLSearchParams(window.location.search)
    const error = urlParams.get('error')
    if (error){
        errorMessage.style.display = 'flex'
        errorMessage.querySelector('p').textContent = error
    }
}

DisplayErrorMessage()

window.addEventListener('click', e => {
    errorMessage.style.display = 'none'
})