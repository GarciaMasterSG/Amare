const form = document.getElementById('LoginForm')
const body = document.querySelector("body")
const html = document.html

form.addEventListener('submit', async e => {
    e.preventDefault()
    let formData = new FormData(e.target)
    const response = await fetch(e.target.action, {
        method : e.target.method,
        body : formData
    })

    if (response.ok){
        const data = await response.json()
        document.documentElement.style.opacity = '0'       
        const timeout = setTimeout(() => {
            window.location.href = data.redirectUrl
        }, 300)
        
    }
})