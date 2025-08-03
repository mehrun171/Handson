(function () {
    var taskInput = document.getElementById('new-task');
    var taskList = document.getElementById('task-list');
    var clearAllBtn = document.getElementById('clear-all');
    var filters = document.querySelectorAll('.filters button');
    var todos = JSON.parse(localStorage.getItem('todos') || '[]');
    var currentFilter = 'all';

    renderTasks();

    taskInput.addEventListener('keyup', function (e) {
        var text = taskInput.value.trim();
        if (e.key === 'Enter' && text) {
            todos.push({ name: text, status: 'pending' });
            saveAndRender();
            taskInput.value = '';
        }
    });

    for (var i = 0; i < filters.length; i++) {
        filters[i].addEventListener('click', function () {
            for (var j = 0; j < filters.length; j++) {
                filters[j].classList.remove('active');
            }
            this.classList.add('active');
            currentFilter = this.getAttribute('data-filter');
            renderTasks();
        });
    }

    clearAllBtn.addEventListener('click', function () {
        todos = [];
        saveAndRender();
    });

    taskList.addEventListener('click', function (e) {
        var li = e.target.closest('li');
        if (!li) return;
        var id = li.getAttribute('data-id');

        if (e.target.tagName === 'INPUT') {
            todos[id].status = e.target.checked ? 'completed' : 'pending';
            saveAndRender();
        }

        if (e.target.classList.contains('delete-btn')) {
            todos.splice(id, 1);
            saveAndRender();
        }
    });

    function renderTasks() {
        var html = '';
        for (var i = 0; i < todos.length; i++) {
            var t = todos[i];
            if (currentFilter !== 'all' && t.status !== currentFilter) continue;
            var checked = t.status === 'completed' ? 'checked' : '';
            var cls = t.status === 'completed' ? 'completed' : '';

            html += '<li data-id="' + i + '" class="task">'
                + '<label><input type="checkbox" ' + checked + '>'
                + '<p class="' + cls + '">' + t.name + '</p></label>'
                + '<div class="actions">'
                + '<button class="delete-btn">Delete</button>'
                + '</div>'
                + '</li>';
        }

        taskList.innerHTML = html || '<li>No tasks here</li>';
        clearAllBtn.disabled = todos.length === 0;
        localStorage.setItem('todos', JSON.stringify(todos));
    }

    function saveAndRender() {
        localStorage.setItem('todos', JSON.stringify(todos));
        renderTasks();
    }
})();
