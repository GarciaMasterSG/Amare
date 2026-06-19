const userWith2WeddingsForm = document.getElementById('UserWith2WeddingsForm');
const selectWedding = document.getElementById('SelectWedding')

const codes = new URLSearchParams(window.location.search).get('weddingCodes').split(',')

const defaultOption = document.createElement('option')
defaultOption.value = ''
defaultOption.textContent = 'Select your current Wedding'
defaultOption.disabled = true
defaultOption.selected = true
selectWedding.appendChild(defaultOption)

codes.forEach(code => {
    const option = document.createElement('option')
    option.value = code
    option.textContent = code
    selectWedding.appendChild(option)
})

userWith2WeddingsForm.addEventListener('submit', async e => {
    e.preventDefault();
    const userSelectedWedding = selectWedding.value
    const response = await fetch('/Auth/UserWith2Weddings', {
        method : 'POST',
        headers : {'Content-Type' : 'application/json'},
        body : JSON.stringify(userSelectedWedding)
    })

    const data = await response.json()

    if (response.ok){
        window.location.href = `${data.redirectUrl}?role=${data.role}`
    }
})