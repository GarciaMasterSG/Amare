const myAccountPanel = document.getElementById('MyAccountPanel')
const totalBudgetAvailable = document.getElementById('TotalBudgetAvailable')
const vendorsToHireForm = document.getElementById('VendorsToHireForm')
const vendorsToHireFormForm = document.querySelector('#VendorsToHireForm form')
const extraExpesesForm = document.getElementById('ExtraExpensesForm')
const extraExpenseFormForm = document.querySelector('#ExtraExpensesForm form')
const selectedTable = document.getElementById('SelectedTable')
const addGuestToTable = document.getElementById('AddGuestToTable')
const addTablesForm = document.getElementById('AddTablesForm')
const tablesForm = document.getElementById('TablesForm')
const weddingScheduleForm = document.getElementById('WeddingScheduleForm')
const tasksDivForm = document.getElementById('TasksDivForm')
const challengeDivForm = document.getElementById('ChallengeDivForm')
const guestPlanningForm = document.getElementById('GuestPlanningForm')
const scheduleForm = document.getElementById('ScheduleForm')
const taskForm = document.getElementById('TaskForm')
const challengeForm = document.getElementById('ChallengeForm')
const guestForm = document.getElementById('GuestForm')
const postLike = document.querySelectorAll('.PostLike')
const postImage = document.getElementById('PostImage')
const uploadImage = document.getElementById('UploadImage')
const uploadPostForm = document.getElementById('UploadPostForm')
const profilePhotoFormInput = document.getElementById('ProfilePhotoFormInput')
const accountPhoto = document.getElementById('AccountPhoto')
const profilePhotoForm = document.getElementById('ProfilePhotoForm')
const editAccountPhoto = document.getElementById('EditAccountPhoto')

profilePhotoFormInput.addEventListener('change', () => {
    const file = profilePhotoFormInput.files[0]
    
    if (file){
        const url = URL.createObjectURL(file)
        accountPhoto.src = url
        profilePhotoForm.style.opacity = '0'
        profilePhotoForm.style.pointerEvents = 'none'
        editAccountPhoto.style.display = 'flex'
        profilePhotoFormInput.value = ''
    }
})

postImage.addEventListener('change', () => {
    uploadImage.style.color = 'red'
    postImage.disabled = true
})

postLike.forEach(like => {
    like.addEventListener('click', () => {
        like.classList.remove('LikeAnimation')
        like.offsetWidth
        like.classList.add('LikeAnimation')
    })
})

totalBudgetAvailable.style.setProperty("--progressbar", "20%")

const sections = [
    {index : 0 , btn : document.getElementById('Dashboard'), text : document.querySelector('#Dashboard h2'), panel : document.getElementById('PanelElements')},
    {index : 1 , btn : document.getElementById('Vendors'), text : document.querySelector('#Vendors h2'), panel : document.getElementById('VendorsPanel')},
    {index : 2 , btn : document.getElementById('Planning'), text : document.querySelector('#Planning h2'), panel : document.getElementById('PlanningPanel')},
    {index : 3 , btn : document.getElementById('LiveFeed'), text : document.querySelector('#LiveFeed h2'), panel : document.getElementById('LiveFeedPanelContainer')},
    {index : 4 , btn : document.getElementById('MyAccount'), text : document.querySelector('#MyAccount h2'), panel : document.getElementById('MyAccountPanel')}
]

let currentIndex = sections[0].index

function setMenuActive(section){
    sections.forEach(s => {
        s.btn.classList.remove('BtnActive')
        s.text.classList.remove('TextActive')
    })
    section.btn.classList.add('BtnActive')
    section.text.classList.add('TextActive')
    if (currentIndex == section.index){
        return
    }
    currentIndex = section.index
    sections.forEach(index => {
        index.panel.classList = ''
        if (currentIndex >= index.index){
            index.panel.classList.add('Active')
        }
        else{
            index.panel.classList.add('NoActive')
        }
    })
    
}

setMenuActive(sections[0])

sections.forEach(section => {
    section.btn.addEventListener('click', () => {
        setMenuActive(section)
    })
})

async function createVendor(){
    const vendorName = new FormData(vendorsToHireFormForm)
    console.log(vendorName)
    const response = await fetch('/api/Vendors', {
        method: 'POST',
        body: vendorName
    })
     if(response.ok){
        const data = await response.json()
        const vendorsFormInputs = vendorsToHireFormForm.elements
        Array.from(vendorsFormInputs).forEach(input => {
            input.value = ''
        })
        console.log(data)
     }
}

async function createExtraExpense(){
    const extraExpenseData = new FormData(extraExpenseFormForm)
    const response = await fetch('/api/Expenses',{
        method: 'POST',
        body: extraExpenseData
    })
    if (response.ok){
        const data = await response.json()
        Array.from(extraExpenseFormForm.elements).forEach(input => {
            input.value = ''
        })
        console.log(data)
    }
}

async function TablesOrganizer() {
    const tableNames = ['Jose', 'Rafaela', 'Amy', 'Renam', 'Rodrigo']
    const radius = 5.75

    tableNames.forEach((person, index) => {
        const seat = document.createElement('div')
        seat.classList.add('seat')
        seat.innerHTML += `<h4> 
            ${person}
        </h4>`
        const angle = (360 / tableNames.length) * index
        seat.style.transform = `
            translate(-50%,-50%)
            rotate(${angle}deg)
            translateY(${radius}rem)
            rotate(-${angle}deg)
        `
        selectedTable.appendChild(seat)
    })
}

TablesOrganizer()

function RemoveGuestToTable(){
    const TableGuests = document.querySelectorAll('.NewGuestOnTable')
    const lastGuest = TableGuests[TableGuests.length - 1]
    addGuestToTable.removeChild(lastGuest)

}

function AddGuestToTable(){
    const div = document.createElement('div')
    div.classList.add('NewGuestOnTable')
    div.innerHTML += `
        <label for=""> Guest Name: </label>
        <input type="text" required>
    `
    addGuestToTable.appendChild(div)
}

function OpenVendorsForm(){
    vendorsToHireForm.style.transform = 'scale(1)'
}

function CloseVendorsForm(){
    vendorsToHireForm.style.transform = 'scale(0)'
}

function OpenExtraExpensesForm(){
    extraExpesesForm.style.transform = 'scale(1)'
}

function CloseExtraExpensesForm(){
    extraExpesesForm.style.transform = 'scale(0)'
}

function CloseAddTablesForm(){
    tablesForm.style.transform = 'scale(0)'
}

function OpenAddTablesForm(){
    tablesForm.style.transform = 'scale(1)'
}

function OpenWeddingScheduleForm(){
    weddingScheduleForm.style.transform = 'scale(1)'
}

function CloseWeddingScheduleForm(){
    weddingScheduleForm.style.transform = 'scale(0)'
}

function OpenTaskForm(){
    tasksDivForm.style.transform = 'scale(1)'
}

function CloseTaskForm(){
    tasksDivForm.style.transform = 'scale(0)'
}

function OpenChallengePlanning(){
    challengeDivForm.style.transform = 'scale(1)'
}

function CloseChallengePlanning(){
    challengeDivForm.style.transform = 'scale(0)'
}

function OpenGuestsForm(){
    guestPlanningForm.style.transform = 'scale(1)'
}

function CloseGuestsForm(){
    guestPlanningForm.style.transform = 'scale(0)'
}

function OpenUploadForm(){
    uploadPostForm.style.transform = 'translateX(0)'
}

function CloseUploadForm(){
    uploadPostForm.style.transform = 'translateX(110%)'
    if (postImage.disabled){
        uploadImage.style.color = 'black'
        postImage.value = ''
        postImage.disabled = false
    }
}

function OpenProfilePhotoForm(){
    profilePhotoForm.style.opacity = '1'
    profilePhotoForm.style.pointerEvents = 'auto'
    editAccountPhoto.style.display = 'none'
}

vendorsToHireForm.addEventListener('submit', e => {
    e.preventDefault()
    createVendor()
})

extraExpesesForm.addEventListener('submit', e => {
    e.preventDefault()
    createExtraExpense()
})

// Sending Information from Planning forms to the Database

addTablesForm.addEventListener('submit', async e => {
    e.preventDefault()
    const table = {
        Name : '',
        Guests : []
    }
    const nameInputs = document.querySelectorAll('#AddTablesForm input')
    table.Name = nameInputs[0].value

    const guestsInputs = document.querySelectorAll('.NewGuestOnTable input')
    guestsInputs.forEach(guest => {
        table.Guests.push(guest.value)
    })

    const response = await fetch('/api/Tables',{
        method : 'POST',
        headers : {'Content-Type' : 'application/json'},
        body : JSON.stringify(table)
    })

    if (response.ok){
        const data = await response.json()
        console.log(data)
        nameInputs[0].value = ''
        guestsInputs.forEach(guest =>{
            guest.value = ''
        })
    }  
    else {
        console.log(`I didn't receive OK`)
    }
})

scheduleForm.addEventListener('submit', async e => {
    e.preventDefault()
    const form = new FormData(scheduleForm)
    const response = await fetch('/api/WeddingEvent', {
       method : 'POST', 
       body : form 
    })
    
    if (response.ok){
        const data = await response.json()
        console.log(data)
    }
    else {
        console.log('Nothing')
    }
})

taskForm.addEventListener('submit', async e => {
    e.preventDefault()
    const form = new FormData(taskForm)
    const response = await fetch('/api/Tasks', {
        method : 'POST',
        body : form
    })
    
    if(response.ok){
        const data = await response.json()
        console.log(data)
    }
    else{
        console.log('Nothing')
    }
})

challengeForm.addEventListener('submit', async e => {
    e.preventDefault()
    const form = new FormData(challengeForm)
    const response = await fetch('/api/Challenges', {
        method : 'POST',
        body : form
    })

    if(response.ok){
        const data = await response.json()
        console.log(data)
    }
    else{
        console.log('Nothing')
    }
})

guestForm.addEventListener('submit', async e => {
    e.preventDefault()
    const form = new FormData(guestForm)
    const response = await fetch('/api/AddGuests', {
        method : 'POST',
        body : form
    })

    if(response.ok){
        const data = await response.json()
        console.log(data)
    }
    else {
        console.log('Nothing')
    }
})




