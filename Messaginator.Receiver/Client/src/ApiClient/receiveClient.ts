import { BaseClient } from './baseClient'

class ReceiveClient extends BaseClient {
	async getMessages(): Promise<Message[]> {
		const response = await this.execute<any>('GET', '/api/messages')
		return response.messages.map((x: any) => ({
			date: Date.parse(x.date),
			author: x.author,
			text: x.text,
			id: x.id,
		}))
	}
}
const instance = new ReceiveClient()
export default instance

export interface Message {
	id: string
	date: Date
	author: string
	text: string
}
