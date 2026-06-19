const myAccountPanel = document.getElementById('MyAccountPanel')
const totalBudgetAvailable = document.getElementById('TotalBudgetAvailable')
const vendorsToHireForm = document.getElementById('VendorsToHireForm')
const vendorsToHireFormForm = document.querySelector('#VendorsToHireForm form')
const extraExpesesForm = document.getElementById('ExtraExpensesForm')
const extraExpenseFormForm = document.querySelector('#ExtraExpensesForm form')
const selectedTable = document.getElementById('SelectedTable')
const weddingAssistantForm = document.getElementById('WeddingAssistantForm')
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
const guestsNoFound = document.getElementById('GuestsNoFound')
const tablePlanning = document.querySelectorAll('.TablePlanning')
const personalizeForm = document.getElementById('PersonalizeFormContainer')
const personalizeFormForm = document.getElementById('PersonalizeForm')
const personalizeButton = document.getElementById('PersonalizeButton')
const budgetAvalaible = document.getElementById('BudgetAvalaible')
const liveFeedPosts = document.getElementById('LiveFeedPosts')
const aIAssistantChat = document.getElementById('AIAssistantChat')

profilePhotoFormInput.addEventListener('change', async () => {
    const file = profilePhotoFormInput.files[0]
    
    if (file){
        const photo = new FormData()
        photo.append('Photo', file)
        const response = await fetch('/api/ProfileImage', {
            method: 'POST',
            body: photo
        })
        
        if (response.ok){
            const url = URL.createObjectURL(file)
            accountPhoto.src = url
            profilePhotoForm.style.opacity = '0'
            profilePhotoForm.style.pointerEvents = 'none'
            editAccountPhoto.style.display = 'flex'
            profilePhotoFormInput.value = ''
        }
    }
})

function IdentifyUserRole(){
    const urlParams = new URLSearchParams(window.location.search)
    
    const role = urlParams.get('role')

    const roleLowerCase = role.toLowerCase()

    if (roleLowerCase == 'guest' && window.innerWidth > 1024){
        window.location.href = '/Auth/Login?error=You are not allowed to access as a Guest. Log in with a Groom or Bride account.'
    }
}

IdentifyUserRole()

window.addEventListener('resize', IdentifyUserRole)

// Get User Profile Photo

async function GetProfilePhoto() {
    const response = await fetch('/api/ProfileImage')
    const data = await response.json()
    console.log(data)

    if (response.ok && data.imageUrl) {
        accountPhoto.src = `https://ik.imagekit.io/Garcia5050/${data.imageUrl}`
    }

}

GetProfilePhoto()

personalizeForm.addEventListener('submit', async e => {
    e.preventDefault()
    const formdata =  new FormData(personalizeFormForm)
    const response = await fetch('/api/WeddingDateLocation', {
        method : 'POST',
        body : formdata
    })

    if (response.ok){
        const weddingLocation = document.querySelector('#WeddingLocation h2')
        weddingLocation.textContent = `Wedding's Location: ${personalizeFormForm.WeddingLocation.value}`
        const weddingDate = document.querySelector('#WeddingDate h2')
        const date = new Date(personalizeFormForm.WeddingDate.value)
        const dataEU = date.toLocaleDateString('en-GB', { day: '2-digit', month: '2-digit', year: '2-digit' })
        weddingDate.textContent = `Wedding's Date: ${dataEU}`
        personalizeFormForm.reset()
        ClosePersonalizeForm()
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
    {index : 4 , btn : document.getElementById('MyAccount'), text : document.querySelector('#MyAccount h2'), panel : document.getElementById('MyAccountPanel')},
    {index : 5 , btn : document.getElementById('WeddingAssistant'), text : document.querySelector('#WeddingAssistant h2'), panel : document.getElementById('WeddingAssistantPanel')}
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

// Send User Message to the AI Assistant

weddingAssistantForm.addEventListener('submit', async e => {

    e.preventDefault()

    const userMessageInput = document.getElementById('UserMessageInput')
    if (userMessageInput.value.trim() == ''){
        return
    }

    const userSendButton = weddingAssistantForm.querySelector('#WeddingAssistantForm button img')
    const form = new FormData(weddingAssistantForm)
    userSendButton.classList.add("SendingMessage")
    aIAssistantChat.innerHTML += `<div class='UserMessage'>
                        <p> ${userMessageInput.value}</p>
                        <img src="/images/Bride.png" alt="">
                    </div>`
    userMessageInput.value = ''
    userMessageInput.style.opacity = '0.5'
    userMessageInput.disabled = true
    const loadingResponse = document.createElement('div')
    loadingResponse.classList.add('AIMessage')
    const aIimage = document.createElement('img')
    aIimage.src = "/images/AmyPA.png"
    loadingResponse.appendChild(aIimage)
    const loadingText = document.createElement('div')
    loadingText.classList.add('LoadingResponse')
    loadingResponse.appendChild(loadingText)
    aIAssistantChat.appendChild(loadingResponse)
    const amyThinking = document.createElement('h3')

    const response = new EventSource(`/api/AIConversation/${form.get('UserMessageInput')}`)

    response.onmessage = (event) => {
        const data = JSON.parse(event.data)
        console.log('Tool call:', data.tool_call)
        console.log('Tool call name:', data.tool_name)
        console.log('Type:', data.type)
        if (data.tool_name == 'search_web'){
            loadingText.remove()
            amyThinking.textContent = 'Amy is searching on internet...'
            loadingResponse.appendChild(amyThinking)
        }

        if (data.type == 'done'){
            response.close()
            amyThinking.remove()
            let final_answer = data.tool_call
            if (final_answer.startsWith('final_answer("')){
                const answer = data.tool_call.replace('final_answer("', '')
                final_answer = answer.replace('")', '')
            }
            userMessageInput.disabled = false
            userMessageInput.style.opacity = '1'
            userSendButton.classList.remove("SendingMessage")
            loadingText.remove() 
            const aIMessage = document.createElement('p')
            aIMessage.textContent = final_answer
            loadingResponse.append(aIMessage)
        }
    }


    /*const amyThinking = document.createElement('h3')
    amyThinking.textContent = 'Amy is searching on internet...'
    loadingResponse.appendChild(amyThinking)*/

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

function OpenPersonalizeForm(){
    personalizeForm.style.transform = 'scale(1)'
    personalizeButton.style.opacity = '0'
    personalizeButton.style.pointerEvents = 'none'
}

function ClosePersonalizeForm(){
    personalizeForm.style.transform = 'scale(0)'
    personalizeButton.style.opacity = '1'
    personalizeButton.style.pointerEvents = 'auto'
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
        img.src = VendorTypeImage(vendorsToHireFormForm.FormVendorType.value)
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

        const ul = document.createElement('ul')

        if (data.length > 0){
            guestsNoFound.style.display = 'flex'
            data.forEach(guest => {
            const li = document.createElement('li')
            li.textContent = guest
            ul.appendChild(li)
            })

            guestsNoFound.appendChild(ul)
        }
    }  
        else {
            TablesOrganizer(table.Guests, table.Name)
        }
})

function CloseNoFoundList(){
    guestsNoFound.style.display = 'none'
    const ul = guestsNoFound.querySelector('ul')
    ul.remove()
}

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
        const btn = document.createElement('button')
        btn.classList.add('ManageRemove')
        btn.textContent = 'Remove'
        btn.onclick = (e) => DeleteFetch(e.target)
        eventElement.appendChild(btn)
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

    console.log(father)

    const {id, controller} = father.dataset

    const response = await fetch(`/api/${controller}/${id}`,{
        method : 'DELETE'
    })

    if(response.ok){
        father.remove()
    }
}

async function TablesOrganizer(SelectedTableDisplay, TableName) {
    const TableNameElement = document.querySelector('#SmallCircle h4')
    const seats = document.querySelectorAll('.seat')
    seats.forEach(seat => {
        seat.remove()
    })
    if (SelectedTableDisplay.length > 0){
        const radius = 5.75

        SelectedTableDisplay.forEach((person, index) => {
            const seat = document.createElement('div')
            seat.classList.add('seat')
            seat.innerHTML += `<h4> 
                ${person}
            </h4>`
            const angle = (360 / SelectedTableDisplay.length) * index
            seat.style.transform = `
                translate(-50%,-50%)
                rotate(${angle}deg)
                translateY(${radius}rem)
                rotate(-${angle}deg)
            `
        selectedTable.appendChild(seat)
        TableNameElement.textContent = TableName
        })
    }
}

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
        tableElement.onclick = async e => {
            const event = e.target.closest('.TablePlanning').dataset.tableName
            const data = (await loadData()).Guests.groupedTables
            const table = data.find(t => t.tableName == event)
            const guestsNames = table.guestNames
            TablesOrganizer(guestsNames, event)
        } 
        tablePlanningList.appendChild(tableElement)
    })
}

listPlanning()

async function listItinerary(){
    const itineraryList = await loadData()
    const events = itineraryList.WeddingEvents
    events.forEach(event => {
        console.log(event.weddingEventTime);
        const eventData = event.weddingEventTime.slice(0, 5);
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
        h3rd.textContent = `${eventData}`
        eventElement.appendChild(h3rd)
        const btn = document.createElement('button')
        btn.classList.add('RemoveTable')
        btn.textContent = 'Remove'
        btn.onclick = (e) => DeleteFetch(e.target)
        eventElement.appendChild(btn)
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

function VendorTypeImage(vendorType){
    switch (vendorType) {
        case 'Venue':
            return "/images/VendorsPhotos/VenueVendor.png"
        case 'Photographer':
            return "/images/VendorsPhotos/PhotographerVendor.png"
        case 'Catering':
            return "/images/VendorsPhotos/CateringVendor.png"
        case 'Florist':
            return "/images/VendorsPhotos/VendorFlorist.png"
        case 'Dj':
            return "/images/VendorsPhotos/VendorDj.png"
        default:
            return "/images/VendorsPhotos/WeddingDefault.jpg"
    }
}

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
            img.src = VendorTypeImage(vendor.vendorType)
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
            img.src = VendorTypeImage(vendor.vendorType)
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
    tables.forEach((t, index) => {
        let peopleTable = 0
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
    const vendors = data.Vendors
    const expenses = data.Expenses
    const maxBudget = data.Budget[0].maxBudget
    let totalExpenses = 0
    expenses.forEach(e => {
        totalExpenses += e.expensePrice
    })
    vendors.forEach(v => {
        if (v.hired == 1){
            totalExpenses += v.vendorPrice
        }
    })
    if (totalExpenses > maxBudget){
        document.documentElement.style.setProperty('--progressBar', '0')
        document.documentElement.style.setProperty('--budgetColorBar', 'red')
        totalBudgetAvailable.dataset.overBudget = `Current expent $${totalExpenses}`
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

async function DisplayLiveFeedPosts() {
    const response = await fetch('/api/LiveFeed')
    const data = await response.json()
    if (response.ok){
        data.forEach(LiveFeedPost => {
            console.log(LiveFeedPost)
            const post = document.createElement('div')
            post.classList.add('Post')
            const h3er = document.createElement('h3')
            h3er.textContent = LiveFeedPost.userName
            post.appendChild(h3er)
            const mainPost = document.createElement('div')
            mainPost.classList.add('mainPost')
            const postLike = document.createElement('div')
            postLike.classList.add('postLike')
            const h5er = document.createElement('h5')
            h5er.textContent = 0
            h5er.addEventListener('click', () => {})
            mainPost.appendChild(postLike)
            const postImageDiv = document.createElement('div')
            postImageDiv.classList.add('PostImage')
            const postImage = document.createElement('img')
            postImage.src = `https://ik.imagekit.io/Garcia5050/${LiveFeedPost.photoFeed}`
            postImageDiv.appendChild(postImage)
            mainPost.appendChild(postImageDiv)
            post.appendChild(mainPost)
            const h4nd = document.createElement('h4')
            h4nd.textContent = LiveFeedPost.description
            post.appendChild(h4nd)
            liveFeedPosts.appendChild(post) 
        })
    }
}

DisplayLiveFeedPosts()

// MOBILE VERSION ↓ ↓ ↓ 

const dashboardLinksMobile = document.querySelectorAll('.DashboardLinksMobile')
const myAccountProfilePhotoMobile = document.getElementById('MyAccountProfilePhotoMobile')
const accountPhotoMobile = document.getElementById('AccountPhotoMobile')
const myAccountPhotoMobileInput = document.getElementById('MyAccountPhotoMobileInput')
const editAccountPhotoMobile = document.getElementById('EditAccountPhotoMobile')
const profilePhotoFormInputMobile = document.getElementById('ProfilePhotoFormInputMobile')
const challengeMobile = document.querySelectorAll('ChallengeMobile')
const challengeDescriptionMobile = document.querySelectorAll('ChallengeDescriptionMobile')
const challengesListMobile = document.getElementById('ChallengesListMobile')
const guestChallengePoints = document.getElementById('GuestChallengePoints')
const leaderboardListMobile = document.getElementById('LeaderboardListMobile')
const weddingItineraryListMobile = document.getElementById('WeddingItineraryListMobile')
const tablesNamesMobile = document.getElementById('TablesNamesMobile')
const guestsOnTable = document.getElementById('GuestsOnTable')
const closeGuestTableMobile = document.querySelector('#GuestsOnTable img')
const uploadPostFormMobile = document.getElementById('UploadPostFormMobile')
const panelMobile = document.getElementById('PanelMobile')
const sendFormMobile = document.getElementById('SendFormMobile')
const liveFeedPostsMobile = document.getElementById('LiveFeedPostsMobile')
const liveFeedPanelMobile = document.getElementById('LiveFeedPanelMobile')
const leaderboardPanelMobile = document.getElementById('LeaderboardPanelMobile')
const challengesPanelMobile = document.getElementById('ChallengesPanelMobile')
const myAccountPanelMobile = document.getElementById('MyAccountPanelMobile')
const weddingItineraryPanelMobile = document.getElementById('WeddingItineraryPanelMobile')
const tablesPanelMobile = document.getElementById('TablesPanelMobile')
const dashboardPanelMobile = document.getElementById('DashboardPanelMobile')
const arrowBackMobile = document.getElementById('ArrowBackMobile')


async function DisplayProfilePhotoMobile(){
    const profilePhoto = await fetch('/api/ProfileImage')
    const profilePhotoData = await profilePhoto.json()
    if (profilePhoto.ok && profilePhotoData.imageUrl){
        accountPhotoMobile.src = `https://ik.imagekit.io/Garcia5050/${profilePhotoData.imageUrl}`
    }
}

DisplayProfilePhotoMobile()

profilePhotoFormInputMobile.addEventListener('change', async () => {
    const file = profilePhotoFormInputMobile.files[0]
    
    if (file){
        const photo = new FormData()
        photo.append('Photo', file)
        const response = await fetch('/api/ProfileImage', {
            method: 'POST',
            body: photo
        })
        
        if (response.ok){
            const url = URL.createObjectURL(file)
            accountPhotoMobile.src = url
            myAccountPhotoMobileInput.style.opacity = '0'
            editAccountPhotoMobile.style.display = 'block'
            profilePhotoFormInputMobile.value = ''
        }
    }
})

function OpenProfilePhotoMobile(){
    myAccountPhotoMobileInput.style.opacity = '1'
    editAccountPhotoMobile.style.display = 'none'
}

function CloseProfilePhotoMobile(){
    myAccountPhotoMobileInput.style.opacity = '0'
    editAccountPhotoMobile.style.display = 'block'
}

function OpenChallengesDescriptionMobile(e){
    console.log(e.currentTarget)
    const button = e.currentTarget
    const challenge = button.closest('.ChallengeMobile');
    const description = challenge.querySelector('.ChallengeDescriptionMobile');
    description.style.opacity = '1'
    description.style.pointerEvents = 'all'
    setTimeout(() => {
        const handler = () => {
            CloseChallengesDescriptionMobile(description)
            window.removeEventListener('click', handler)
        }

        window.addEventListener('click', handler)
    }, 300)
}

function CloseChallengesDescriptionMobile(element){
    element.style.opacity = '0'
    element.style.pointerEvents = 'none'
}

dashboardLinksMobile.forEach(icon => {
    icon.addEventListener('click', (e) => {
        const dashboardIcon = e.currentTarget
        
        const dashboardIconInfo = dashboardIcon.getBoundingClientRect()

        const centerX = dashboardIconInfo.width / 2
        const centerY = dashboardIconInfo.height / 2

        const sparks = 18

        for (let i = 0; i < sparks; i++) {
            const spark = document.createElement('span')
            spark.classList.add('sparks')
            spark.style.left = `${centerX}px`
            spark.style.top = `${centerY}px`
            const rotation = Math.random() * 360
            const distance = Math.random() * 90 
            spark.style.setProperty('--rotation', `${rotation}deg`)         
            spark.style.setProperty('--distance', `${distance}px`)
            dashboardIcon.appendChild(spark)
            setTimeout(() => {
                spark.remove()
            }, 1000)
        }
    })
})

async function ChallengeDone(e){
    const div = e.currentTarget.closest('.ChallengeMobile')
    const challengeId = div.dataset.id
    const points = div.dataset.points
    const controller = div.dataset.controller
    let userPoints = parseInt(guestChallengePoints.textContent)
    const response = await fetch (`/api/${controller}/${challengeId}/${points}`, {
        method : 'POST'
    })

    if (response.ok){
        userPoints += parseInt(points)
        guestChallengePoints.textContent = userPoints
        div.style.opacity = '0'
        setTimeout(() => {
            div.remove()
        }, 300)
    }
}

async function GetGuestsChallenges(){
    const guestChallenge = await fetch('/api/Challenges/GuestChallenges')
    const guestChallengeData = await guestChallenge.json()
    return guestChallengeData
}

async function DisplayChallengesMobile(){
    console.log('Displaying challenges')
    const challenges = await GetGuestsChallenges()
    challenges.forEach(challenge => {
        const diver = document.createElement('div')
        diver.classList.add('ChallengeMobile')
        diver.dataset.id = challenge.id
        diver.dataset.points = challenge.challengePoints
        diver.dataset.controller = 'Challenges'
        const divnd = document.createElement('div')
        divnd.classList.add('ChallengeInfoMobile')
        const h3er = document.createElement('h3')
        h3er.textContent = challenge.challengeName
        divnd.appendChild(h3er)
        const h4er = document.createElement('h4')
        h4er.textContent = `${challenge.challengePoints} points`
        divnd.appendChild(h4er)
        diver.appendChild(divnd)
        const divrd = document.createElement('div')
        divrd.classList.add('ChallengeButtonsMobile')
        const btner = document.createElement('button')
        btner.textContent = 'Done'
        btner.onclick = (e) => ChallengeDone(e)
        divrd.appendChild(btner)
        const btnnd = document.createElement('button')
        btnnd.textContent = 'Description'
        btnnd.onclick = (e) => OpenChallengesDescriptionMobile(e)
        divrd.appendChild(btnnd)
        diver.appendChild(divrd)
        const divth = document.createElement('div')
        divth.classList.add('ChallengeDescriptionMobile')
        const per = document.createElement('p')
        per.textContent = challenge.description
        divth.appendChild(per)
        diver.appendChild(divth)
        challengesListMobile.appendChild(diver)

    })  
}

DisplayChallengesMobile()

async function DisplayGuestLeaderboard(){
    const response = await fetch("/api/Leaderboard")
    const Leaderboard = await response.json()
    console.log(Leaderboard)
    Leaderboard.forEach((guest, index) => {
        const diver = document.createElement('div')
        diver.classList.add('LeaderboardGuest')
        const h3er = document.createElement('h3')
        h3er.classList.add('PodiumNumber')
        h3er.textContent = `${index + 1}.`
        diver.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.textContent = guest.name
        diver.appendChild(h3nd)
        const h3rd = document.createElement('h3')
        h3rd.textContent = `${guest.userPoints} points`
        diver.appendChild(h3rd)
        leaderboardListMobile.appendChild(diver)
    })
}

DisplayGuestLeaderboard()

function leaderboardPodium(){
    const guestsOnLeaderboard = document.querySelectorAll('.PodiumNumber')
    let count = 1
    console.log(guestsOnLeaderboard.length)
    guestsOnLeaderboard.forEach(guest => {
        console.log(count)
        if (count == 1){
            guest.classList.add('TopLeaderboard1')
            guest.style.color = 'gold'
        }
        else if (count == 2){
            guest.classList.add('TopLeaderboard2')
            guest.style.color = 'silver'
        }
        else if (count == 3){
            guest.classList.add('TopLeaderboard3')
            guest.style.color = 'bronze'
        }

        count++

    })
}

setTimeout(leaderboardPodium, 1000)

async function DisplayWeddingItineraryMobile(){
    const weddingItineraryList = (await loadData()).WeddingEvents
    weddingItineraryList.forEach(event => {
        const eventTime = (event.weddingEventTime).slice(0,5)
        const diver = document.createElement('div')
        diver.classList.add('WeddingItineraryListClass')
        const h3er = document.createElement('h3')
        h3er.textContent = '→'
        diver.appendChild(h3er)
        const h3nd = document.createElement('h3')
        h3nd.textContent = `${event.weddingEventName}`
        diver.appendChild(h3nd)
        const h3rd = document.createElement('h3')
        h3rd.textContent = `${eventTime}`
        diver.appendChild(h3rd)
        weddingItineraryListMobile.appendChild(diver)
    })
}

DisplayWeddingItineraryMobile()

async function DisplayNameTableMobile(){
    const tables = (await loadData()).Guests.groupedTables
    tables.forEach(table => {
        const diver = document.createElement('div')
        diver.style.borderBottom = '1px solid gold'
        diver.style.display = 'flex'
        diver.style.justifyContent = 'center'
        diver.dataset.tableName = table.tableName
        const h2er = document.createElement('h2')
        h2er.textContent = `${table.tableName}`
        diver.appendChild(h2er)
        tablesNamesMobile.appendChild(diver)
        diver.addEventListener('click', e => {
            const clickedTable = e.currentTarget
            const tableSelected = clickedTable.dataset.tableName
            tables.forEach(tableName => {
                if (tableName.tableName === tableSelected){
                    const guestOnTableSelected = tableName.guestNames
                    guestOnTableSelected.forEach(guest => {
                        const h3er = document.createElement('h3')
                        h3er.classList.add('ThisIsAGuest')
                        h3er.textContent = `- ${guest}`
                        guestsOnTable.appendChild(h3er)
                    })
                }
            })
            guestsOnTable.style.transform = 'scale(1)'
        })
    })
}

DisplayNameTableMobile()

function closeDisplayGuestOnTableMobile(){
    const TheseAreGuests = document.querySelectorAll('.ThisIsAGuest')
    guestsOnTable.style.transform = 'scale(0)'
    TheseAreGuests.forEach(guest => {
        guest.remove()
    })
}

function CloseUploadFormMobile(){
    uploadPostFormMobile.style.transform = 'translateX(110%)'
}

function OpenUploadFormMobile(){
    uploadPostFormMobile.style.transform = 'translateX(0)'
}

// LiveFeed Function for Eliminate Padding

function isLiveFeedActive(active){
    if (active !== true && active !== false){
        active = false
    }

    let setLiveFeedActive = active

    console.log(setLiveFeedActive)

    switch (setLiveFeedActive){
        case (true):
            panelMobile.style.padding = '0'
        case (false):
            panelMobile.style.padding = '1'
    }
}

isLiveFeedActive(true)

uploadPostFormMobile.addEventListener('submit', async (e) => {
    e.preventDefault()
    const dataForm = new FormData(uploadPostFormMobile)
    const response = await fetch('/api/LiveFeed', {
        method: 'POST',
        body: dataForm
    })
    
    if (response.ok){
        const liveFeedWelcomeMobile = document.getElementById('LiveFeedWelcomeMobile')
        const urlImage = URL.createObjectURL(dataForm.get('PhotoFeed'))
        const post = document.createElement('div')
        post.classList.add('post')
        const h3er = document.createElement('h3')
        const UserName = liveFeedWelcomeMobile.textContent.slice(10)
        h3er.textContent = UserName
        post.appendChild(h3er)
        const mainPost = document.createElement('div')
        mainPost.classList.add('mainPost')
        const postLike = document.createElement('div')
        postLike.classList.add('postLike')
        const h5er = document.createElement('h5')
        h5er.textContent = 0
        h5er.addEventListener('click', () => {})
        mainPost.appendChild(postLike)
        const postImage = document.createElement('img')
        postImage.src = urlImage
        mainPost.appendChild(postImage)
        post.appendChild(mainPost)
        const h4nd = document.createElement('h4')
        const postDescription = dataForm.get('Description')
        h4nd.textContent = postDescription
        post.appendChild(h4nd)
        liveFeedPostsMobile.appendChild(post)
    }
})

async function DisplayLiveFeedPostsMobiles() {
    const response = await fetch('/api/LiveFeed')
    const data = await response.json()
    if (response.ok){
        data.forEach(LiveFeedPost => {
            console.log(LiveFeedPost)
            const post = document.createElement('div')
            post.classList.add('Post')
            const h3er = document.createElement('h3')
            h3er.textContent = LiveFeedPost.userName
            post.appendChild(h3er)
            const mainPost = document.createElement('div')
            mainPost.classList.add('mainPost')
            const postLike = document.createElement('div')
            postLike.classList.add('postLike')
            const h5er = document.createElement('h5')
            h5er.textContent = 0
            h5er.addEventListener('click', () => {})
            mainPost.appendChild(postLike)
            const postImageDiv = document.createElement('div')
            postImageDiv.classList.add('PostImage')
            const postImage = document.createElement('img')
            postImage.src = `https://ik.imagekit.io/Garcia5050/${LiveFeedPost.photoFeed}`
            postImageDiv.appendChild(postImage)
            mainPost.appendChild(postImageDiv)
            post.appendChild(mainPost)
            const h4nd = document.createElement('h4')
            h4nd.textContent = LiveFeedPost.description
            post.appendChild(h4nd)
            liveFeedPostsMobile.appendChild(post) 
        })
    }
}

DisplayLiveFeedPostsMobiles()

function DisplayMyAccountPanel(){
    setTimeout(() => {
        dashboardPanelMobile.style.display = 'none'
        myAccountPanelMobile.style.display = 'flex'
        myAccountPanelMobile.offsetHeight
        myAccountPanelMobile.style.opacity = '1'
        myAccountPanelMobile.style.pointerEvents = 'auto'
    }, 750)
    setTimeout(() => {
        arrowBackMobile.style.display = 'flex'
    }, 1000)
}

function DisplayChallengePanel(){
    setTimeout(() => {
        dashboardPanelMobile.style.display = 'none'
        challengesPanelMobile.style.display = 'flex'
        challengesPanelMobile.offsetHeight
        challengesPanelMobile.style.opacity = '1'
        challengesPanelMobile.style.pointerEvents = 'auto'
    }, 750)
    setTimeout(() => {
        arrowBackMobile.style.display = 'flex'
    }, 1000)
}

function DisplayLeaderboardPanel(){
    setTimeout(() => {
        dashboardPanelMobile.style.display = 'none'
        leaderboardPanelMobile.style.display = 'flex'
        leaderboardPanelMobile.offsetHeight
        leaderboardPanelMobile.style.opacity = '1'
        leaderboardPanelMobile.style.pointerEvents = 'auto'
    }, 750)
    setTimeout(() => {
        arrowBackMobile.style.display = 'flex'
    }, 1000)
}

function DisplayLiveFeedPanel(){
    setTimeout(() => {
        dashboardPanelMobile.style.display = 'none'
        liveFeedPanelMobile.style.display = 'flex'
        liveFeedPostsMobile.offsetHeight
        liveFeedPanelMobile.style.opacity = '1'
        liveFeedPanelMobile.style.pointerEvents = 'auto'
    }, 750)
    setTimeout(() => {
        arrowBackMobile.style.display = 'flex'
    }, 1000)
}

function DisplayWeddingItineraryPanel(){
    setTimeout(()=> {
        dashboardPanelMobile.style.display = 'none'
        weddingItineraryPanelMobile.style.display = 'flex'
        weddingItineraryPanelMobile.offsetHeight
        weddingItineraryPanelMobile.style.opacity = '1'
        weddingItineraryPanelMobile.style.pointerEvents = 'auto'
    }, 750)
    setTimeout(() => {
        arrowBackMobile.style.display = 'flex'
    }, 1000)
}

function DisplayTablesPanel(){
    setTimeout(() => {
        dashboardPanelMobile.style.display = 'none'
        tablesPanelMobile.style.display = 'flex'
        tablesPanelMobile.offsetHeight
        tablesPanelMobile.style.opacity = '1'
        tablesPanelMobile.style.pointerEvents = 'auto'
    }, 750)
    setTimeout(() => {
        arrowBackMobile.style.display = 'flex'
    }, 1000)
}

const mobilePanels = [myAccountPanelMobile, challengesPanelMobile, leaderboardPanelMobile, liveFeedPanelMobile, 
    weddingItineraryPanelMobile, tablesPanelMobile
]

function DisplayDasboardPanelMobile(){
    mobilePanels.forEach(panel => {
        panel.style.display = 'none'
        panel.style.opacity = '0'
        panel.style.pointerEvents = 'none'
    })
    guestsOnTable.style.transform = 'scale(0)'
    arrowBackMobile.style.display = 'none'
    dashboardPanelMobile.style.display = 'flex'
}

























