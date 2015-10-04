class OperationQueueResponse(object):
    """description of class"""

    def __init__(self):
        self.queues = []
        #return super(OperationQueueResponse, self).__init__()

    def add_queue(self, queue):
        self.queues.append(queue)