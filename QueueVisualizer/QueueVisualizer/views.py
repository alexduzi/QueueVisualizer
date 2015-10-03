"""
Routes and views for the flask application.
"""

from datetime import datetime
from flask import render_template
from QueueVisualizer import app
from Infra.Queue_repository import Queue_repository as Repository
import Models

QUEUE_SERVICE = 'http://localhost:7789/QueueService.svc?wsdl'

@app.route('/')
@app.route('/home')
def home():
    """Renders the home page."""

    repo = Repository(QUEUE_SERVICE)
    result = repo.get_queues(OperationQueueRequest(False, ''))

    return render_template(
        'index.html',
        title='Home Page',
        year=datetime.now().year,
        queue = result
    )


@app.route('/purge/<queue>')
def home(queue):
    """Renders the home page."""

    repo = Repository(QUEUE_SERVICE)
    repo.purge_queue(OperationQueueRequest(queue.isPublic, queue.queueName))
    queue.queueName = ''
    result = repo.get_queues(OperationQueueRequest(queue.isPublic, queue.queueName))

    return render_template(
        'index.html',
        title='Home Page',
        year=datetime.now().year,
        queues = result
    )