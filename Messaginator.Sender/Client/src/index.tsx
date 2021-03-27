import React from 'react'
import ReactDOM from 'react-dom'

import './index.css'
import 'react-toastify/dist/ReactToastify.css'
import { ToastContainer } from 'react-toastify'
import { Send } from './Send'
ReactDOM.render(
	<React.StrictMode>
		<ToastContainer />
		<Send />
	</React.StrictMode>,
	document.getElementById('root'),
)
