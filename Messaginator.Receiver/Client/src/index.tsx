import React from 'react'
import ReactDOM from 'react-dom'

import './index.css'
import 'react-toastify/dist/ReactToastify.css'
import { ToastContainer } from 'react-toastify'
import { MessagesList } from './MessagesList'

ReactDOM.render(
	<React.StrictMode>
		<ToastContainer />
		<MessagesList />
	</React.StrictMode>,
	document.getElementById('root'),
)
