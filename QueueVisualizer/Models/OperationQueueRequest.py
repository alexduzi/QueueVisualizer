from Models import Queue

class OperationQueueRequest(object):
    """description of class"""
    
    def __init__(self, isPublic, queueName):
        self.queue = Queue(queueName, 0, isPublic)



