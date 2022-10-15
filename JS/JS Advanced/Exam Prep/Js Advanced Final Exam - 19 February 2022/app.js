function solve() {
  let addWorkerButton = document.getElementById('add-worker');

  let fname = document.getElementById('fname');
  let lname = document.getElementById('lname');
  let email = document.getElementById('email');
  let brith = document.getElementById('birth');
  let position = document.getElementById('position');
  let salary = document.getElementById('salary');
  let sum = Number(0);

  addWorkerButton.addEventListener('click',(e)=>{
 e.preventDefault();
 let _fname = fname.value;
 let _lname = lname.value;
 let _email = email.value;
 let _brith = brith.value;
 let _position = position.value;
 let _salary = salary.value;
if(_fname === ''||_lname === ''||_email === ''||_brith === ''||_position === ''||_salary === ''){
    return;
}
  let tbody = document.getElementById('tbody');
  let tr = document.createElement('tr');
  let td = document.createElement('td');
  let firedButton = document.createElement('button');
  let editButton = document.createElement('button');
  let sumElement = document.getElementById('sum');

    firedButton.setAttribute('class','fired');
    firedButton.textContent = `Fired`;
    editButton.setAttribute('class','edit');
    editButton.textContent = 'Edit';

    td.appendChild(firedButton);
    td.appendChild(editButton);

  tr.innerHTML = `<td>${_fname}</td><td>${_lname}</td><td>${_email}</td><td>${_brith}</td><td>${_position}</td><td>${_salary}</td>`;

  sum += Number(_salary);
  sumElement.textContent = Number(sum).toFixed(2);

  tr.appendChild(td);
  tbody.appendChild(tr);

      fname.value='';
      lname.value='';
      email.value='';
      brith.value='';
      position.value='';
      salary.value='';

      editButton.addEventListener('click',function () {
          fname.value = _fname;
          lname.value = _lname;
          email.value = _email;
          brith.value = _brith;
          position.value = _position;
          salary.value = _salary;

          sum -= _salary;
          sumElement.textContent = Number(sum).toFixed(2);

          editButton.parentElement.parentElement.remove();
      })

      firedButton.addEventListener('click',function () {
          sum -= _salary;
          sumElement.textContent = Number(sum).toFixed(2);

          firedButton.parentElement.parentElement.remove();
      })
  })
}
solve()