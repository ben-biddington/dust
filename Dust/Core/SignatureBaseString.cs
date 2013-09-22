﻿using System;
using Dust.Core.SignatureBaseStringParts.Earl;
using Dust.Core.SignatureBaseStringParts.Parameters;
using Dust.Core.SignatureBaseStringParts.Verb;

namespace Dust.Core {
	public class Request {
		public Uri Url { get; set; }
		public string Verb { get; set; }
	}

	public class SignatureBaseString {
		private readonly Request _request;
		private readonly OAuthParameters _oAuthParameters;

		public SignatureBaseString(Request request, OAuthParameters oAuthParameters) {
			_request = request;
			_oAuthParameters = oAuthParameters;
		}

		public string Value {
			get {
				return RequestMethod + Ampersand + RequestUrl + Ampersand + Parameters;
			}
		}

		protected string Ampersand {
			get { return "&"; }
		}

		protected string RequestMethod {
			get { return new VerbPart(_request).Value; }
		}

		private string RequestUrl {
			get { return new EarlPart(_request.Url).Value; }
		}

		protected string Parameters {
			get { return new ParameterPart(_request, _oAuthParameters).Value; }
		}
	}
}