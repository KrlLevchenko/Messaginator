import React, { useEffect, useState } from 'react'
import { format } from 'date-fns'
import {
	Button,
	CircularProgress,
	Container,
	createStyles,
	Table,
	TableBody,
	TableCell,
	TableHead,
	TableRow,
	Theme,
} from '@material-ui/core'
import receiveClient, { Message } from './ApiClient/receiveClient'
import { makeStyles } from '@material-ui/core/styles'
const useStyles = makeStyles((theme: Theme) =>
	createStyles({
		button: {
			marginTop: theme.spacing(2),
			marginBottom: theme.spacing(2),
		},
	}),
)
export const MessagesList: React.FC = () => {
	const [messages, setMessages] = useState<Message[]>([])
	const classes = useStyles()

	const [isLoading, setIsLoading] = useState(false)

	const loadMessages = () => {
		setIsLoading(true)

		receiveClient
			.getMessages()
			.then((x) => setMessages(x))
			.finally(() => setIsLoading(false))
	}

	const handleLoadMessagesClick = () => loadMessages()

	useEffect(() => {
		loadMessages()
	}, [])

	if (isLoading) {
		return <CircularProgress />
	}

	return (
		<Container>
			<Button className={classes.button} onClick={handleLoadMessagesClick} variant="contained" color="primary">
				Загрузить
			</Button>

			<Table size="small" aria-label="a dense table">
				<TableHead>
					<TableRow>
						<TableCell>Дата</TableCell>
						<TableCell>Автор</TableCell>
						<TableCell>Текст</TableCell>
					</TableRow>
				</TableHead>
				<TableBody>
					{messages.map((row) => (
						<TableRow key={row.id}>
							<TableCell>{format(row.date, 'dd.MM.yyyy HH:mm')}</TableCell>
							<TableCell>{row.author}</TableCell>
							<TableCell>{row.text}</TableCell>
						</TableRow>
					))}
				</TableBody>
			</Table>
		</Container>
	)
}
