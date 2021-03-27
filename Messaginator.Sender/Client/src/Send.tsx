import React, { ChangeEvent, useState } from 'react'
import { Box, Button, CircularProgress, createStyles, TextField, Theme } from '@material-ui/core'
import sendClient, { SendMessageRequest } from './ApiClient/sendClient'
import { makeStyles } from '@material-ui/core/styles'
import { toast } from 'react-toastify'

const useStyles = makeStyles((theme: Theme) =>
	createStyles({
		block: {
			margin: theme.spacing(1),
		},
		progress: {
			marginRight: theme.spacing(1),
		},
	}),
)

export const Send: React.FC = () => {
	const classes = useStyles()

	const [isLoading, setIsLoading] = useState(false)
	const [request, setRequest] = useState<SendMessageRequest>({
		author: '',
		text: '',
	})
	const handleChangeAuthor = (element: ChangeEvent<HTMLInputElement>) => {
		setRequest({ ...request, author: element.target.value })
	}
	const handleChangeText = (element: ChangeEvent<HTMLInputElement>) => {
		setRequest({ ...request, text: element.target.value })
	}

	const handleSubmitForm = (ev: any) => {
		ev.preventDefault()

		if (!request.author) {
			toast.error('Укажите автора')
			return
		}

		if (!request.text) {
			toast.error('Укажите текст')
			return
		}

		if (isLoading) return

		setIsLoading(true)
		sendClient
			.sendMessage(request)
			.then((resp) => {
				setRequest({
					author: request.author,
					text: '',
				})
				toast.success(`Сообщение отправлено. Id: ${resp.id}`)
			})
			.catch(() => console.error('Error sending message'))
			.finally(() => setIsLoading(false))
	}

	return (
		<form method="POST" onSubmit={handleSubmitForm}>
			<Box className={classes.block}>
				<TextField
					id="outlined-basic"
					value={request.author}
					disabled={isLoading}
					size="small"
					name="author"
					onChange={handleChangeAuthor}
					label="Автор"
					variant="outlined"
				/>
			</Box>
			<Box className={classes.block}>
				<TextField
					id="outlined-basic"
					multiline={true}
					disabled={isLoading}
					value={request.text}
					size="small"
					name="text"
					rows={5}
					onChange={handleChangeText}
					label="Текст сообщения"
					variant="outlined"
				/>
			</Box>
			<Box className={classes.block}>
				<Button type="submit" disabled={isLoading} variant="contained" color="primary">
					{isLoading && <CircularProgress size={16} className={classes.progress} />}
					Отправить сообщение
				</Button>
			</Box>
		</form>
	)
}
