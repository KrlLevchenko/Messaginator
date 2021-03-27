import { BaseClient } from './baseClient'

class SendClient extends BaseClient {
	sendMessage(request: SendMessageRequest): Promise<SendMessageResponse> {
		return this.execute<SendMessageResponse>('POST', '/api/messages', request)
	}
}
const instance = new SendClient()
export default instance

export interface SendMessageRequest {
	author: string
	text: string
}

export interface SendMessageResponse {
	id: string
}
