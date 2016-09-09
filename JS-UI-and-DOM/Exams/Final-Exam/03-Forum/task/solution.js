function solve() {
	return function() {
		var template = '<h1>{{title}}</h1>' +
			'<ul>' +
			'{{#posts}}' +
			'<li>' +
			'<div class="post">' +
			'<p class="author">' +
			'{{#if author}}<a class="user" href="/user/{{author}}">{{author}}</a> ' +
			'{{else}}<a class="anonymous">Anonymous</a> {{/if}}' +
			'</p>' +
			'<pre class="content">{{{text}}}</pre>' +
			'</div>' +
			'{{#comments}}' +
			'{{#if deleted}}{{else}}' +
			'<ul>' +
			'<li>' +
			'<div class="comment">' +
			'<p class="author">' +
			'{{#if author}}<a class="user" href="/user/{{author}}">{{author}}</a> ' +
			'{{else}}<a class="anonymous">Anonymous</a> {{/if}}' +
			'</p>' +
			'<pre class="content">{{{text}}}</pre>' +
			'</div>' +
			'</li>' +
			'</ul>' +
			'{{/if}}' +
			'{{/comments}}' +
			'</li>' +
			'{{/posts}}' +
			'</ul>';

		return template;
	}
}

// submit the above

if(typeof module !== 'undefined') {
	module.exports = solve;
}
