from pysimplesoap.client import SoapClient
from Models import OperationQueueRequest, OperationQueueResponse, Queue


class Queue_repository(object):
    

    def __init__(self, wsdl):
        self.wsdl = wsdl


    def get_queues(self, request):
        client = SoapClient(wsdl= self.wsdl, trace = False)
        response = client.GetAll(entity = { 'IsPublic': request.queue.isPublic, 'QueueName': request.queue.queueName })
        result = response['GetAllResult']
        response = OperationQueueResponse()
        for queue in result['Queues']:
            queueEntity = queue['QueueEntity']
            # print queueEntity['QtyMsg'], queueEntity['QueueName']
            queue_obj = Queue(queueEntity['QueueName'], queueEntity['QtyMsg'], request.queue.isPublic)
            response.add_queue(queue_obj)

        return response


    def purge_queue(self, request):
        client = SoapClient(wsdl= self.wsdl, trace = False)
        client.Purge(entity = { 'IsPublic': request.queue.isPublic, 'QueueName': request.queue.queueName })
        