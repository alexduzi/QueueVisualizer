"""
Routes and views for the flask application.
"""

from datetime import datetime
from flask import render_template, request, has_request_context
from QueueVisualizerWeb import app
from Infra.Queue_repository import Queue_repository as Repository
from Models import OperationQueueRequest, OperationQueueResponse, Queue
import re

QUEUE_SERVICE = 'http://localhost:6668/QueueService.svc?wsdl'

#QUEUE_SERVICE = 'http://localhost:52438/QueueService.svc?wsdl' # DEBUG

@app.route('/')
@app.route('/home')
def home():
    """Renders the home page."""

    queueName = None
    isPublic = False
    if request.args:
        queueName = re.sub('[\s+]', '', request.args.get('txtQueueName'))
        isPublic = request.args.get('chkIsPublic')

    repo = Repository(QUEUE_SERVICE)
    operationRequest = OperationQueueRequest(isPublic, queueName) 
    result = repo.get_queues(operationRequest)

    return render_template(
        'index.html',
        title='Home Page',
        year=datetime.now().year,
        queueResult = result
    )


@app.route('/purge', methods=["POST"])
def purge():
    """Renders the home page."""

    if request.json:
        repo = Repository(QUEUE_SERVICE)
        operationRequest = None
        for queue in request.json:
            operationRequest = OperationQueueRequest(queue['chkIsPublic'], queue['txtQueueName'])
            repo.purge_queue(operationRequest)
        
    result = repo.get_queues(OperationQueueRequest(False, ''))

    return render_template(
        'index.html',
        title='Home Page',
        year=datetime.now().year,
        queueResult = result
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
