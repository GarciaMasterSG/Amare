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
const tablePlanningList = document.getElementById('TablesPlanningList')
const weddingItinerary = document.getElementById('WeddingItinerary')
const manageTasks = document.getElementById('ManageTasks')
const challengeList = document.getElementById('ChallengesList')
const guestPlanningList = document.getElementById('GuestPlanningList')
const vendorsToHireList = document.getElementById('VendorsToHireList')
const vendorsHired = document.getElementById('VendorsHiredList')
const extraExpenseList = document.getElementById('ExtraExpensesList')
const dashboardGuests = document.querySelector('#TotalGuests h1')
const dashboardTasks = document.querySelector('#TotalTasks h1')
const dashboardTable = document.getElementById('Tables')
const dashboardNumberTables = document.getElementById('DashboardNumberTables')
const dashboardExpenses = document.getElementById('Expenses')
const chartBudget = document.getElementById('ChartBudget')
const budgetDaysToGo = document.getElementById('BudgetDaysToGo')

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

function CloseProfilePhotoForm(){
    profilePhotoForm.style.opacity = '0'
    editAccountPhoto.style.display = 'flex'
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

vendorsToHireForm.addEventListener('submit', async e => {
    e.preventDefault()
    const vendorName = new FormData(vendorsToHireFormForm)
    console.log(vendorName)
    const response = await fetch('/api/Vendors', {
        method: 'POST',
        body: vendorName
    })
    if(response.ok){
        const data = await response.json()
        const diver = document.createElement('VendorToHire')
        diver.classList.add('VendorToHire')
        diver.dataset.id = data
        diver.dataset.controller = 'Vendors'
        diver.dataset.hired = 0
        const img = document.createElement('img')
        img.src = "/images/VendorsPhotos/WeddingDefault.jpg"
        diver.appendChild(img)
        const subDiv = document.createElement('div')
        subDiv.classList.add('VendorToHireTitle')
        const h3er = document.createElement('h3')
        h3er.textContent = `${vendorsToHireFormForm.FormVendorName.value}`
        subDiv.appendChild(h3er)
        const btner = document.createElement('button')
        btner.classList.add('ToHireButton')
        btner.textContent = 'Hired'
        btner.onclick = (e) => UpdateFetchVendor(e.target)
        subDiv.appendChild(btner)
        const btnnd = document.createElement('button')
        btnnd.textContent = 'Remove'
        btnnd.onclick = (e) => DeleteFetch(e.target)
        btnnd.classList.add('ToHireRemoveButton')
        subDiv.appendChild(btnnd)
        diver.appendChild(subDiv)
        const h3nd = document.createElement('h3')
        h3nd.textContent = `${vendorsToHireFormForm.FormVendorDescription.value}`
        diver.appendChild(h3nd)
        vendorsToHireList.appendChild(diver)

        vendorsToHireFormForm.reset()
        
    }
    
})

extraExpesesForm.addEventListener('submit', async e => {
    e.preventDefault()
    const extraExpenseData = new FormData(extraExpenseFormForm)
    const response = await fetch('/api/Expenses',{
        method: 'POST',
        body: extraExpenseData
    })
    if (response.ok){
        const data = await response.json()
        const diver = document.createElement('div')
        diver.classList.add('ExtraExpense')
        diver.dataset.id = data
        diver.dataset.controller = 'Expenses'
        const h3er = document.createElement('h3')
        h3er.textContent = `${extraExpenseFormForm.ExpenseName.value}`
        diver.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.textContent = `$${extraExpenseFormForm.ExpensePrice.value}`
        diver.appendChild(h3nd)
        const btner = document.createElement('button')
        btner.classList.add('ExtraExpenseRemoveButton')
        btner.onclick = (e) => DeleteFetch(e.target)
        btner.textContent = 'Remove'
        diver.appendChild(btner)
        extraExpenseList.appendChild(diver)

        extraExpenseFormForm.reset()
    }
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
        const eventElement = document.createElement('div')
        eventElement.classList.add('WeddingActivity')
        eventElement.dataset.id = data
        eventElement.dataset.controller = 'WeddingEvent'
        const h3er = document.createElement('h3')
        h3er.textContent = `→`
        eventElement.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.textContent = `${scheduleForm.WeddingEventForm.value}`
        eventElement.appendChild(h3nd)
        const h3rd = document.createElement('h3')
        h3rd.textContent = `${scheduleForm.WeddingEventTime.value}`
        eventElement.appendChild(h3rd)
        weddingItinerary.appendChild(eventElement)

        scheduleForm.reset()
        
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
        const taskElement = document.createElement('div')
        taskElement.classList.add('ManageTask')
        taskElement.dataset.id = data
        taskElement.dataset.controller = 'Tasks'
        const diver = document.createElement('div')
        diver.style.backgroundColor = 'red'
        const taskDate = new Date(taskForm.TaskDateForm.value)
        const taskDateEU = taskDate.toLocaleDateString('en-GB', {
            year: '2-digit',
            month: '2-digit',
            day: '2-digit'
        })
        diver.classList.add('ManageTaskActive')
        taskElement.appendChild(diver)
        const h3er = document.createElement('h3')
        h3er.textContent = `${taskForm.TaskNameForm.value}`
        taskElement.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.textContent = `${taskDateEU}`
        taskElement.appendChild(h3nd)
        const Btner = document.createElement('button')
        Btner.classList.add('ManageRemove')
        Btner.textContent = 'Remove'
        Btner.onclick = (e) => DeleteFetch(e.target)
        taskElement.appendChild(Btner)
        const Btnnd = document.createElement('button')
        Btnnd.classList.add('ManageDone')
        Btnnd.textContent = 'Done'
        Btnnd.onclick = (e) => UpdateFetchTask(e.target)
        taskElement.appendChild(Btnnd)
        manageTasks.appendChild(taskElement)

        taskForm.reset()
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
        const challengeElement = document.createElement('div')
        challengeElement.classList.add('Challenge')
        challengeElement.dataset.id = data
        challengeElement.dataset.controller = 'Challenges'
        const diver = document.createElement('div')
        diver.classList.add('ChallengeName')
        const h2er = document.createElement('h2')
        h2er.textContent = `${challengeForm.ChallengeName.value}`
        diver.appendChild(h2er)
        const h3er = document.createElement('h3')
        h3er.textContent = `${challengeForm.ChallengePoints.value} points`
        diver.appendChild(h3er)
        challengeElement.appendChild(diver)
        const Btner = document.createElement('button')
        Btner.classList.add('ChallengeRemove')
        Btner.textContent = 'Remove'
        Btner.onclick = (e) => DeleteFetch(e.target)
        challengeElement.appendChild(Btner)
        const Btnnd = document.createElement('button')
        Btnnd.textContent = 'Description'
        Btnnd.onclick = function(){

        }
        challengeElement.appendChild(Btnnd)
        challengeList.appendChild(challengeElement)

        challengeForm.reset()
    }
})

guestForm.addEventListener('submit', async e => {
    e.preventDefault()
    const form = new FormData(guestForm)
    const response = await fetch('/api/AddGuests', {
        method : 'POST',
        body : form
    })

    if (response.ok){
        const data = await response.json()
        const diver = document.createElement('div')
        diver.dataset.id = data
        diver.dataset.controller = 'AddGuests'
        diver.classList.add('GuestPlanning')
        const h3er = document.createElement('h3')
        h3er.classList.add('GuestPlanningNumber')
        index = GuestPlanningList.children.length
        h3er.textContent = `${(index + 1)}`
        diver.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.classList.add('GuestPlanningName')
        h3nd.textContent = `${guestForm.GuestName.value}`
        diver.appendChild(h3nd)
        const Btner = document.createElement('button')
        Btner.classList.add('ManageRemove')
        Btner.textContent = 'Remove'
        Btner.onclick = (e) => DeleteFetch(e.target)
        diver.appendChild(Btner)
        guestPlanningList.appendChild(diver)

        guestForm.reset()
    }
})

// Featching Data from Database

let dataPromise = null;

function loadData() {

    if (dataPromise) {
        return dataPromise;
    }

    dataPromise = (async () => {
        const [
            VendorsResponse,
            ExpensesResponse,
            WeddingEventsResponse,
            TasksResponse,
            ChallengesResponse,
            GuestsResponse,
            BudgetResponse
        ] = await Promise.all([
            fetch('/api/Vendors').then(r => r.json()),
            fetch('/api/Expenses').then(r => r.json()),
            fetch('/api/WeddingEvent').then(r => r.json()),
            fetch('/api/Tasks').then(r => r.json()),
            fetch('/api/Challenges').then(r => r.json()),
            fetch('/api/AddGuests').then(r => r.json()),
            fetch('/api/Budget').then(r => r.json())
        ]);

        console.log(VendorsResponse,
            ExpensesResponse,
            WeddingEventsResponse,
            TasksResponse,
            ChallengesResponse,
            GuestsResponse,
            BudgetResponse)

        return {
            Vendors: VendorsResponse,
            Expenses: ExpensesResponse,
            WeddingEvents: WeddingEventsResponse,
            Tasks: TasksResponse,
            Challenges: ChallengesResponse,
            Guests: GuestsResponse,
            Budget: BudgetResponse
        };

    })();

    return dataPromise;
}

// Displaying loadData on the webpage

async function UpdateFetchVendor(element){

    const father = element.closest('[data-id]')

    const {id, controller} = father.dataset

    const response = await fetch(`/api/${controller}/${id}`, {
        method : 'PATCH',
    })

    if (response.ok){
        father.remove()
        vendorsHired.appendChild(father)
        
    }
}

async function UpdateFetchTask(element){
    const father = element.closest('[data-id]')

    const point = father.querySelector('.ManageTaskActive')

    if (point.style.backgroundColor == 'red'){ 
       const {id, controller} = father.dataset

        const response = await fetch(`/api/${controller}/${id}`, {
        method : 'PATCH'
        })
    
        if (response.ok){
            point.style.backgroundColor = 'green'
            const doneButton = father.querySelector('.ManageDone')
            doneButton.remove()
        } 
    }
}

async function DeleteFetch(element){
    console.log(element)

    const father = element.closest('[data-id]')

    const {id, controller} = father.dataset

    const response = await fetch(`/api/${controller}/${id}`,{
        method : 'DELETE'
    })

    if(response.ok){
        father.remove()
    }
}

async function TablesOrganizer() {
    const tableList = await loadData()
    if (tableList.Guests.groupedTables.length > 0){
        const tableNames = tableList.Guests.groupedTables[0].guestNames
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
}

TablesOrganizer()

async function listPlanning(){
    const planningList = await loadData()
    const tableNames = planningList.Guests.groupedTables
    tableNames.forEach((table, index) => {
        const tableElement = document.createElement('div')
        tableElement.classList.add('TablePlanning')
        tableElement.dataset.tableName = table.tableName
        const h3er = document.createElement('h3')
        h3er.textContent = `${index + 1}`
        tableElement.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.textContent = `${table.tableName}`
        tableElement.appendChild(h3nd)
        let count = 0
        table.guestNames.forEach(guest => {
            count++
        })
        const h3rd = document.createElement('h3')
        h3rd.textContent = `${count} people`
        tableElement.appendChild(h3rd)
        const button = document.createElement('button')
        button.classList.add('RemoveTable')
        button.textContent = 'Remove'
        button.onclick = (e) => {
            const response = fetch(`/api/guesttable/${table.tableName}`, {
                method : 'DELETE'
            })

            const father = e.target.closest('[data-table-name]')

            if (response.ok){ 
                father.remove()
            }
        }
        tableElement.appendChild(button)
        tablePlanningList.appendChild(tableElement)
    })
}

listPlanning()

async function listItinerary(){
    const itineraryList = await loadData()
    const events = itineraryList.WeddingEvents
    events.forEach(event => {
        const eventElement = document.createElement('div')
        eventElement.classList.add('WeddingActivity')
        eventElement.dataset.id = event.id
        eventElement.dataset.controller = 'WeddingEvent'
        const h3er = document.createElement('h3')
        h3er.textContent = `→`
        eventElement.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.textContent = `${event.weddingEventName}`
        eventElement.appendChild(h3nd)
        const h3rd = document.createElement('h3')
        h3rd.textContent = `${event.weddingEventTime}`
        eventElement.appendChild(h3rd)
        weddingItinerary.appendChild(eventElement)
    })
}

listItinerary()

async function listTasks(){
    const tasksList = await loadData()
    const tasks = tasksList.Tasks
    tasks.forEach(task => {
        const taskElement = document.createElement('div')
        taskElement.classList.add('ManageTask')
        taskElement.dataset.id = task.id
        taskElement.dataset.controller = 'Tasks'
        const diver = document.createElement('div')
        if (task.taskCompleted == 0){
            diver.style.backgroundColor = 'red'
        }
        else {
            diver.style.backgroundColor = 'green'
        }
        const taskDate = new Date(task.taskDate)
        const taskDateEU = taskDate.toLocaleDateString('en-GB', {
            year: '2-digit',
            month: '2-digit',
            day: '2-digit'
        })
        diver.classList.add('ManageTaskActive')
        taskElement.appendChild(diver)
        const h3er = document.createElement('h3')
        h3er.textContent = `${task.taskName}`
        taskElement.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.textContent = `${taskDateEU}`
        taskElement.appendChild(h3nd)
        const Btner = document.createElement('button')
        Btner.classList.add('ManageRemove')
        Btner.textContent = 'Remove'
        Btner.onclick = (e) => DeleteFetch(e.target)
        taskElement.appendChild(Btner)
        const Btnnd = document.createElement('button')
        Btnnd.classList.add('ManageDone')
        Btnnd.textContent = 'Done'
        Btnnd.onclick = (e) => UpdateFetchTask(e.target)
        taskElement.appendChild(Btnnd)
        manageTasks.appendChild(taskElement)
    })
}

listTasks()

async function listChallenges(){
    const challengesList = await loadData()
    const challenges = challengesList.Challenges
    challenges.forEach(challenge => {
        const challengeElement = document.createElement('div')
        challengeElement.classList.add('Challenge')
        challengeElement.dataset.id = challenge.id
        challengeElement.dataset.controller = 'Challenges'
        const diver = document.createElement('div')
        diver.classList.add('ChallengeName')
        const h2er = document.createElement('h2')
        h2er.textContent = `${challenge.challengeName}`
        diver.appendChild(h2er)
        const h3er = document.createElement('h3')
        h3er.textContent = `${challenge.challengePoints} points`
        diver.appendChild(h3er)
        challengeElement.appendChild(diver)
        const Btner = document.createElement('button')
        Btner.classList.add('ChallengeRemove')
        Btner.textContent = 'Remove'
        Btner.onclick = (e) => DeleteFetch(e.target)
        challengeElement.appendChild(Btner)
        const Btnnd = document.createElement('button')
        Btnnd.textContent = 'Description'
        Btnnd.onclick = function(){

        }
        challengeElement.appendChild(Btnnd)
        challengeList.appendChild(challengeElement)
    })
}

listChallenges()

async function GuestList(){
    const GuestList = await loadData()
    const Guests = GuestList.Guests.guestsList
    console.log(Guests)
    Guests.forEach((guest,index) => {
        const diver = document.createElement('div')
        diver.dataset.id = guest.id
        diver.dataset.controller = 'AddGuests'
        diver.classList.add('GuestPlanning')
        const h3er = document.createElement('h3')
        h3er.classList.add('GuestPlanningNumber')
        h3er.textContent = `${(index + 1)}`
        diver.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.classList.add('GuestPlanningName')
        h3nd.textContent = `${guest.guestName}`
        diver.appendChild(h3nd)
        const Btner = document.createElement('button')
        Btner.classList.add('ManageRemove')
        Btner.textContent = 'Remove'
        Btner.onclick = (e) => DeleteFetch(e.target)
        diver.appendChild(Btner)
        guestPlanningList.appendChild(diver)
    })
}

GuestList()

async function VendorsList(){
    const VendorsList = await loadData()
    const Vendors = VendorsList.Vendors
    Vendors.forEach(vendor => {
        if (vendor.hired == 0){
            const diver = document.createElement('VendorToHire')
            diver.classList.add('VendorToHire')
            diver.dataset.id = vendor.id
            diver.dataset.controller = 'Vendors'
            diver.dataset.hired = vendor.hired
            const img = document.createElement('img')
            img.src = "/images/VendorsPhotos/WeddingDefault.jpg"
            diver.appendChild(img)
            const subDiv = document.createElement('div')
            subDiv.classList.add('VendorToHireTitle')
            const h3er = document.createElement('h3')
            h3er.textContent = `${vendor.vendorName}`
            subDiv.appendChild(h3er)
            const btner = document.createElement('button')
            btner.classList.add('ToHireButton')
            btner.textContent = 'Hired'
            btner.onclick = (e) => UpdateFetchVendor(e.target)
            subDiv.appendChild(btner)
            const btnnd = document.createElement('button')
            btnnd.textContent = 'Remove'
            btnnd.onclick = (e) => DeleteFetch(e.target)
            btnnd.classList.add('ToHireRemoveButton')
            subDiv.appendChild(btnnd)
            diver.appendChild(subDiv)
            const h3nd = document.createElement('h3')
            h3nd.textContent = `${vendor.vendorDescription}`
            diver.appendChild(h3nd)
            vendorsToHireList.appendChild(diver)
        }
        else {
            const diver = document.createElement('VendorToHire')
            diver.classList.add('VendorHired')
            diver.dataset.id = vendor.id
            diver.dataset.controller = 'Vendors'
            const img = document.createElement('img')
            img.src = "/images/VendorsPhotos/WeddingDefault.jpg"
            diver.appendChild(img)
            const subDiv = document.createElement('div')
            subDiv.classList.add('VendorHiredTitle')
            const h3er = document.createElement('h3')
            h3er.textContent = `${vendor.vendorName}`
            subDiv.appendChild(h3er)
            const btnnd = document.createElement('button')
            btnnd.textContent = 'Remove'
            btnnd.classList.add('HiredRemoveButton')
            btnnd.onclick = (e) => DeleteFetch(e.target)
            subDiv.appendChild(btnnd)
            diver.appendChild(subDiv)
            const h3nd = document.createElement('h3')
            h3nd.textContent = `${vendor.vendorDescription}`
            diver.appendChild(h3nd)
            vendorsHired.appendChild(diver)
        }
    })
}

VendorsList()

async function ExpensesList(){
    const extraExpenses = await loadData()
    const extraExpensesList = extraExpenses.Expenses
    extraExpensesList.forEach(expense => {
        const diver = document.createElement('div')
        diver.classList.add('ExtraExpense')
        diver.dataset.id = expense.id
        diver.dataset.controller = 'Expenses'
        const h3er = document.createElement('h3')
        h3er.textContent = `${expense.expenseName}`
        diver.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.textContent = `$${expense.expensePrice}`
        diver.appendChild(h3nd)
        const btner = document.createElement('button')
        btner.classList.add('ExtraExpenseRemoveButton')
        btner.onclick = (e) => DeleteFetch(e.target)
        btner.textContent = 'Remove'
        diver.appendChild(btner)
        extraExpenseList.appendChild(diver)
    })
}

ExpensesList()

async function DisplayTotalGuests(){
    let guestsCount = 0
    const newGuests = (await loadData()).Guests
    const Guests = newGuests.guestsList
    Guests.forEach(() => {
        guestsCount += 1
    })

    dashboardGuests.textContent = guestsCount   
}

DisplayTotalGuests()

async function DisplayTotalTasks(){
    let tasksPendingCount = 0
    const tasks = (await loadData()).Tasks
    tasks.forEach(t => {
        if (t.taskCompleted == 0){
            tasksPendingCount += 1
        }
    })

    dashboardTasks.textContent = tasksPendingCount
}

DisplayTotalTasks()

async function DisplayTablesDashboard(){
    const newtables = (await loadData()).Guests
    const tables = newtables.groupedTables
    let peopleTable = 0
    tables.forEach((t, index) => {
        const diver = document.createElement('div')
        diver.classList.add('Table')
        const h3er = document.createElement('h3')
        h3er.textContent = (index + 1)
        diver.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.textContent = t.tableName 
        diver.appendChild(h3nd)
        t.guestNames.forEach(g => {
            peopleTable += 1
        })
        const h3rd = document.createElement('h3')
        h3rd.textContent = `${peopleTable} people`
        diver.appendChild(h3rd)
        dashboardTable.appendChild(diver)
    })
}

DisplayTablesDashboard()


async function DisplayNumberTables(){
    let numberTablesCount = 0
    const numberTables = (await loadData()).Guests.groupedTables
    numberTables.forEach(() => {
        numberTablesCount += 1
    })

    dashboardNumberTables.textContent = `< ${numberTablesCount} >`
}

DisplayNumberTables()

async function DisplayExpensesDashboard(){
    let expensesList = []
    const data = await loadData()
    const expenses = []
    data.Expenses.forEach(d => {
        const forDisplay = { Name : d.expenseName, Price : d.expensePrice}
        expensesList.push(forDisplay)
    })
    data.Vendors.forEach(d => {
        const forDisplay = { Name : d.vendorName, Price : d.vendorPrice}
        expensesList.push(forDisplay)
    })

    console.log(expensesList)
    expensesList.forEach(e => {
        const diver = document.createElement('div')
        diver.classList.add('Expense')
        const h3er = document.createElement('h3')
        h3er.textContent = e.Name
        diver.appendChild(h3er)
        const h3nd = document.createElement('sh3')
        h3nd.textContent = `$${e.Price}`
        diver.appendChild(h3nd)
        dashboardExpenses.appendChild(diver)
    })
}

DisplayExpensesDashboard()

async function displayMaxBudget(){
    const rawMaxBudget = (await loadData()).Budget[0]
    const maxBudget = rawMaxBudget.maxBudget
    chartBudget.innerHTML += `<h3> Total Budget <br> $${maxBudget} </h3>`
}

displayMaxBudget()

async function BudgetBar(){
    const data = await loadData()
    const expenses = data.Expenses
    const maxBudget = data.Budget[0].maxBudget
    let totalExpenses = 0
    expenses.forEach(e => {
        totalExpenses += e.expensePrice
    })
    if (totalExpenses > maxBudget){
        document.documentElement.style.setProperty('--progressBar', '0')
        document.documentElement.style.setProperty('--budgetColorBar', 'red')

        console.log('Over budget')
    }
    else {
    document.documentElement.style.setProperty('--progressBar', `${(totalExpenses / maxBudget) * 100}%`)
    }
}

BudgetBar()

async function TotalBudgetAvalaible(){
    const maxBudget = (await loadData()).Budget[0].maxBudget
    const h3er = document.createElement('h3')
    const h3er2 = document.createElement('h3')
    h3er.textContent = `$${maxBudget}`
    h3er2.textContent = `< $${maxBudget} >`
    totalBudgetAvailable.appendChild(h3er)
    budgetDaysToGo.appendChild(h3er2)
}

TotalBudgetAvalaible()












