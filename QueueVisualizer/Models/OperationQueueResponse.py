class OperationQueueResponse(object):
    """description of class"""

    def __init__(self):
        self.queues = []


    def add_queue(self, queue):
        self.queues.append(queue)