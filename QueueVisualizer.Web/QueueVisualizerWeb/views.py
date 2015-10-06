"""
Routes and views for the flask application.
"""

from datetime import datetime
from flask import render_template
from QueueVisualizerWeb import app
from Infra.Queue_repository import Queue_repository as Repository
from Models import OperationQueueRequest, OperationQueueResponse, Queue

QUEUE_SERVICE = 'http://localhost:7789/QueueService.svc?wsdl'

@app.route('/')
@app.route('/home')
def home():
    """Renders the home page."""

    repo = Repository(QUEUE_SERVICE)
    operationRequest = OperationQueueRequest(False, '') 
    result = repo.get_queues(operationRequest)

    return render_template(
        'index.html',
        title='Home Page',
        year=datetime.now().year,
        queueResult = result
    )

@app.route('/purge')
def purge():
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

@app.route('/contact')
def contact():
    """Renders the contact page."""
    return render_template(
        'contact.html',
        title='Contact',
        year=datetime.now().year,
        message='Your contact page.'
    )

@app.route('/about')
def about():
    """Renders the about page."""
    return render_template(
        'about.html',
        title='About',
        year=datetime.now().year,
        message='Your application description page.'
    )
